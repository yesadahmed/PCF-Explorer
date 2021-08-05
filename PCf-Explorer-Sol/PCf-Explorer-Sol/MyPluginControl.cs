using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using PCf_Explorer_Sol.Manager;
using PCf_Explorer_Sol.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using XrmToolBox.Extensibility;

namespace PCf_Explorer_Sol
{
	public partial class MyPluginControl : PluginControlBase
	{
		private Settings mySettings;

		public MyPluginControl()
		{
			InitializeComponent();
		}

		private void MyPluginControl_Load(object sender, EventArgs e)
		{
			ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

			// Loads or creates the settings for the plugin
			if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
			{
				mySettings = new Settings();

				LogWarning("Settings not found => a new settings file has been created!");
			}
			else
			{
				LogInfo("Settings found and loaded");
			}
			LoadPCFContorl();
		}

		private void tsbClose_Click(object sender, EventArgs e)
		{
			CloseTool();
		}

		private void tsbSample_Click(object sender, EventArgs e)
		{
			// The ExecuteMethod method handles connecting to an
			// organization if XrmToolBox is not yet connected
			//ExecuteMethod(GetAccounts);
		}

		private void GetAccounts()
		{
			WorkAsync(new WorkAsyncInfo
			{
				Message = "Getting accounts",
				Work = (worker, args) =>
				{
					args.Result = Service.RetrieveMultiple(new QueryExpression("account")
					{
						TopCount = 50
					});
				},
				PostWorkCallBack = (args) =>
				{
					if (args.Error != null)
					{
						MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					var result = args.Result as EntityCollection;
					if (result != null)
					{
						MessageBox.Show($"Found {result.Entities.Count} accounts");
					}
				}
			});
		}

		/// <summary>
		/// This event occurs when the plugin is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
		{
			// Before leaving, save the settings
			SettingsManager.Instance.Save(GetType(), mySettings);
		}

		/// <summary>
		/// This event occurs when the connection has been updated in XrmToolBox
		/// </summary>
		public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
		{
			base.UpdateConnection(newService, detail, actionName, parameter);

			if (mySettings != null && detail != null)
			{
				mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
				LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
			}
		}

		#region My Implementations

		private void LoadPCFContorl()
		{
			WorkAsync(new WorkAsyncInfo
			{
				Message = "Loading PCF Controls (Field/Dataset)",
				Work = (worker, args) =>
				{
					PCFManager pCFManager = new PCFManager(ConnectionDetail.ServiceClient);

					args.Result = pCFManager.GetPCfControls();

				},
				PostWorkCallBack = (args) =>
				{
					if (args.Error != null)
					{
						MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					var result = args.Result as List<PCFModel>;
					if (result != null && result.Count > 0)
					{
						LoadflowList(result);

						//MessageBox.Show($"Found {result.Entities.Count} accounts");
					}
				}
			});

		}

		private void LoadflowList(List<PCFModel> pcfControls)
		{
			listViewPCF.Items.Clear();
			listViewPCF.MultiSelect = false;
			ListViewItem item = null;

			var groupTrg = new ListViewGroup($"PCF Controls: {pcfControls.Count}");
			listViewPCF.Groups.Add(groupTrg);
			// Initialize the tile size.
			listViewPCF.TileSize = new Size(560, 43);
			ImageList myImageList = new ImageList();
			myImageList.ColorDepth = ColorDepth.Depth32Bit;
			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/PCf_transparent.png"));
			myImageList.ImageSize = new Size(47, 47);
			listViewPCF.LargeImageList = myImageList;
			listViewPCF.View = View.Tile;

			listViewPCF.Columns.AddRange(new ColumnHeader[]
			  {new ColumnHeader(), new ColumnHeader(), new ColumnHeader()});

			foreach (var pcf in pcfControls)
			{
				item = new ListViewItem(new string[] { pcf.name, pcf.compatibledatatypes, pcf.createdon.ToString("MM/dd/yyyy H:mm") }, 0, groupTrg);
				item.Tag = pcf.ClientJson;//as cache
				listViewPCF.Items.Add(item);

			}
			RenderPieChart(pcfControls);
			RenderCustomDefaultControls(pcfControls);

			comboBoxcustom.Tag = pcfControls;
			comboBoxtotal.Tag = pcfControls;
			comboBoxtotal.SelectedIndex = 0;
			comboBoxcustom.SelectedIndex = 0;

		}
		Image LoadImage(string url)
		{
			System.Net.WebRequest request =
				System.Net.WebRequest.Create(url);

			System.Net.WebResponse response = request.GetResponse();
			System.IO.Stream responseStream =
				response.GetResponseStream();

			Bitmap bmp = new Bitmap(responseStream);

			responseStream.Dispose();

			return bmp;
		}

		void RenderPieChart(List<PCFModel> pcfControls)
		{

			var fDatasetCount = pcfControls.Count(p => p.IsFieldtype.Equals(false));
			var filedsCount = pcfControls.Count(p => p.IsFieldtype.Equals(true));

			DataTable dt = new DataTable("PCFControls");
			//dt.Clear();
			dt.Columns.Add("Type");
			dt.Columns.Add("Count");
			DataRow _newRow = dt.NewRow();
			_newRow["Type"] = "Field";
			_newRow["Count"] = filedsCount;
			dt.Rows.Add(_newRow);
			_newRow = dt.NewRow();
			_newRow["Type"] = "Dataset";
			_newRow["Count"] = fDatasetCount;
			dt.Rows.Add(_newRow);


			chartpie.Series[0].ChartType = SeriesChartType.Pie;
			chartpie.DataSource = dt;
			chartpie.Series[0].XValueMember = "Type";
			chartpie.Series[0].YValueMembers = "Count";
			chartpie.Titles.Add($"Total PCF Controls: {pcfControls.Count}");

			chartpie.Series[0].IsValueShownAsLabel = true;
			chartpie.ChartAreas[0].Area3DStyle.Enable3D = true;
			chartpie.BackColor = Color.Transparent;
			chartpie.ChartAreas[0].BackColor = Color.Transparent;
			chartpie.Legends[0].BackColor = Color.Transparent;

		}

		void RenderCustomDefaultControls(List<PCFModel> pcfControls)
		{
			var mscontrol = pcfControls.Count(p => p.DefaultMSControl.Equals(true));
			var customcontrol = pcfControls.Count(p => p.DefaultMSControl.Equals(false));

			DataTable dt = new DataTable("PCFControls");
			//dt.Clear();
			dt.Columns.Add("Type");
			dt.Columns.Add("Count");
			DataRow _newRow = dt.NewRow();
			_newRow["Type"] = "Microsoft";
			_newRow["Count"] = mscontrol;
			dt.Rows.Add(_newRow);
			_newRow = dt.NewRow();
			_newRow["Type"] = "Custom";
			_newRow["Count"] = customcontrol;
			dt.Rows.Add(_newRow);

			chart1.Series[0].ChartType = SeriesChartType.Pie;
			chart1.DataSource = dt;
			chart1.Series[0].XValueMember = "Type";
			chart1.Series[0].YValueMembers = "Count";
			chart1.Titles.Add($"Microsoft vs Custom Controls: {pcfControls.Count}");

			chart1.Series[0].IsValueShownAsLabel = true;
			chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
			chart1.BackColor = Color.Transparent;
			chart1.ChartAreas[0].BackColor = Color.Transparent;
			chart1.Legends[0].BackColor = Color.Transparent;

			Series S = chart1.Series[0];
			for (int idx = 0; idx < dt.Columns.Count; idx++)
			{
				DataPoint dp = new DataPoint();
				dp.ToolTip = "adnan" + idx;
				chart1.Series[0].Points.Add(dp);
			}

		}
		#endregion

		private void btnsearch_Click(object sender, EventArgs e)
		{

		}

		private void txtsearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ListViewItem foundItem =
	   listViewPCF.FindItemWithText(txtsearch.Text, false, 0, true);
				if (foundItem != null)
				{
					listViewPCF.Items[foundItem.Index].Selected = true;
					foundItem.EnsureVisible();

				}
				e.Handled = true;
			}
		}

		private void comboBoxtotal_SelectedIndexChanged(object sender, EventArgs e)
		{
			IEnumerable<PCFModel> items = null;
			if (comboBoxtotal.SelectedItem == null) return;
			var lst = comboBoxtotal.Tag as List<PCFModel>;
			if (lst != null && lst.Count > 0)
			{
				listBox1.Items.Clear();
				   var selection = Convert.ToString(comboBoxtotal.SelectedItem);
				if (selection == "Field")
				{
					items = lst.Where(p => p.compatibledatatypes != "Grid");
				}
				else
				{
					items = lst.Where(p => p.compatibledatatypes.Equals("Grid"));
				}

				if (items.Any())
				{
					foreach (var item in items)
					{
						listBox1.Items.Add(item.name);
					}
				}

			}
		}

		private void comboBoxcustom_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			IEnumerable<PCFModel> items = null;
			if (comboBoxcustom.SelectedItem == null) return;
			var lst = comboBoxcustom.Tag as List<PCFModel>;
			if (lst != null && lst.Count > 0)
			{
				listBox2.Items.Clear();
				   var selection = Convert.ToString(comboBoxcustom.SelectedItem);
				if (selection == "Custom")
				{
					items = lst.Where(p => p.DefaultMSControl.Equals(false));
				}
				else
				{
					items = lst.Where(p => p.DefaultMSControl.Equals(true));
				}
				if (items.Any())
				{
					foreach (var item in items)
					{
						listBox2.Items.Add(item.name);
					}
				}
			}
		}
	}
}