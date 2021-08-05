using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
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
		Dictionary<int, string> dic = new Dictionary<int, string>();
		public MyPluginControl()
		{
			InitializeComponent();
		}

		private void MyPluginControl_Load(object sender, EventArgs e)
		{
			//ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

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
			LoadCrmComponentsTypes();
			LoadPCFContorl();
		}

		void LoadCrmComponentsTypes()
		{
			dic.Add(1, "Entity");
			dic.Add(2, "Attribute");
			dic.Add(3, "Relationship");
			dic.Add(4, "Attribute Picklist Value");
			dic.Add(5, "Attribute Lookup Value");
			dic.Add(6, "View Attribute");
			dic.Add(7, "Localized Label");
			dic.Add(8, "Relationship Extra Condition");
			dic.Add(9, "Option Set");
			dic.Add(10, "Entity Relationship");
			dic.Add(11, "Entity Relationship Role");
			dic.Add(12, "Entity Relationship Relationships");
			dic.Add(13, "Managed Property");
			dic.Add(14, "Entity Key");
			dic.Add(16, "Privilege");
			dic.Add(17, "PrivilegeObjectTypeCode");
			dic.Add(20, "Role");
			dic.Add(21, "Role Privilege");
			dic.Add(22, "Display String");
			dic.Add(23, "Display String Map");
			dic.Add(24, "Form");
			dic.Add(25, "Organization");
			dic.Add(26, "Saved Query");
			dic.Add(29, "Workflow");
			dic.Add(31, "Report");
			dic.Add(32, "Report Entity");
			dic.Add(33, "Report Category");
			dic.Add(34, "Report Visibility");
			dic.Add(35, "Attachment");
			dic.Add(36, "Email Template");
			dic.Add(37, "Contract Template");
			dic.Add(38, "KB Article Template");
			dic.Add(39, "Mail Merge Template");
			dic.Add(44, "Duplicate Rule");
			dic.Add(45, "Duplicate Rule Condition");
			dic.Add(46, "Entity Map");
			dic.Add(47, "Attribute Map");
			dic.Add(48, "Ribbon Command");
			dic.Add(49, "Ribbon Context Group");
			dic.Add(50, "Ribbon Customization");
			dic.Add(52, "Ribbon Rule");
			dic.Add(53, "Ribbon Tab To Command Map");
			dic.Add(55, "Ribbon Diff");
			dic.Add(59, "Saved Query Visualization");
			dic.Add(60, "System Form");
			dic.Add(61, "Web Resource");
			dic.Add(62, "Site Map");
			dic.Add(63, "Connection Role");
			dic.Add(64, "Complex Control");
			dic.Add(70, "Field Security Profile");
			dic.Add(71, "Field Permission");
			dic.Add(90, "Plugin Type");
			dic.Add(91, "Plugin Assembly");
			dic.Add(92, "SDK Message Processing Step");
			dic.Add(93, "SDK Message Processing Step Image");
			dic.Add(95, "Service Endpoint");
			dic.Add(150, "Routing Rule");
			dic.Add(151, "Routing Rule Item");
			dic.Add(152, "SLA");
			dic.Add(153, "SLA Item");
			dic.Add(154, "Convert Rule");
			dic.Add(155, "Convert Rule Item");
			dic.Add(65, "Hierarchy Rule");
			dic.Add(161, "Mobile Offline Profile");
			dic.Add(162, "Mobile Offline Profile Item");
			dic.Add(165, "Similarity Rule");
			dic.Add(66, "Custom Control");
			dic.Add(68, "Custom Control Default Config");
			dic.Add(166, "Data Source Mapping");
			dic.Add(201, "SDKMessage");
			dic.Add(202, "SDKMessageFilter");
			dic.Add(203, "SdkMessagePair");
			dic.Add(204, "SdkMessageRequest");
			dic.Add(205, "SdkMessageRequestField");
			dic.Add(206, "SdkMessageResponse");
			dic.Add(207, "SdkMessageResponseField");
			dic.Add(210, "WebWizard");
			dic.Add(18, "Index");
			dic.Add(208, "Import Map");
			dic.Add(300, "Canvas App");
			dic.Add(371, "Connector");
			dic.Add(372, "Connector");
			dic.Add(380, "Environment Variable Definition");
			dic.Add(381, "Environment Variable Value");
			dic.Add(400, "AI Project Type");
			dic.Add(401, "AI Project");
			dic.Add(402, "AI Configuration");
			dic.Add(430, "Entity Analytics Configuration");
			dic.Add(431, "Attribute Image Configuration");
			dic.Add(432, "Entity Image Configuration");


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
						result = result.OrderByDescending(P => P.createdon).ToList();
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

		private void listViewPCF_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListView.SelectedListViewItemCollection items = this.listViewPCF.SelectedItems;
			if (items.Count <= 0) return;
			LoadDependentPCFControl(items);
		}


		void LoadDependentPCFControl(ListView.SelectedListViewItemCollection items)
		{
			ListGroupDisplyModel lstGroup = null;
			ListViewItem itemNew = null;
			listViewDetails.Clear();
			PCFClientJsonModel client = null;
			RetrieveDependentComponentsRequest request = null;
			//https://github.com/yesadahmed/PCF-Explorer/blob/main/PCf_transparent.png?raw=true
			ImageList myImageList = new ImageList();
			myImageList.ColorDepth = ColorDepth.Depth32Bit;
			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/form_transparent.png"));
			myImageList.ImageSize = new Size(47, 47);
			listViewDetails.LargeImageList = myImageList;
			listViewDetails.View = View.Tile;


			foreach (ListViewItem item in items)
			{
				client = item.Tag as PCFClientJsonModel;
				request =
				  new RetrieveDependentComponentsRequest
				  {
					  ObjectId = new Guid(client.CustomControlId),
					  ComponentType = 66 //custom control
				  };
			}

			try
			{
				var response =
					(RetrieveDependentComponentsResponse)ConnectionDetail.ServiceClient.Execute(
					request);

				if (response != null && response.EntityCollection != null)
				{
					lstGroup = new ListGroupDisplyModel();
					lstGroup.Forms = new List<CRMFormModel>();
					foreach (var ent in response.EntityCollection.Entities)
					{
						var depType = ent.GetAttributeValue<OptionSetValue>("dependentcomponenttype");
						var depCompId = ent.GetAttributeValue<Guid>("dependentcomponentobjectid");

						var groupName = dic[depType.Value];
						switch (depType.Value)
						{
							case 60:
								if (string.IsNullOrWhiteSpace(lstGroup.GroupName))
									lstGroup.GroupName = dic[depType.Value];

								var formProp = GetformProperties(depCompId);
								if (formProp != null)
								{
									lstGroup.Forms.Add(formProp);
								}
								break;

						}

					}

					if (lstGroup != null)
					{
						var grp = new ListViewGroup(lstGroup.GroupName);
						listViewDetails.Groups.Add(grp);
						listViewDetails.TileSize = new Size(560, 43);
						listViewDetails.Columns.AddRange(new ColumnHeader[]
					  {new ColumnHeader(), new ColumnHeader()});

						foreach (var litem in lstGroup.Forms)
						{
							itemNew = new ListViewItem(new string[] { litem.Name, litem.entity }, 0, grp);

							listViewDetails.Items.Add(itemNew);
						}


					}

				}
			}
			catch (Exception ex)
			{


			}

		}

		CRMFormModel GetformProperties(Guid FormId)
		{
			CRMFormModel cRMFormModel = null;

			var form = ConnectionDetail.ServiceClient.Retrieve("systemform", FormId, new ColumnSet("name", "objecttypecode"));

			if (form != null)
			{
				cRMFormModel = new CRMFormModel();
				cRMFormModel.FormId = FormId;
				cRMFormModel.entity = "Entity: " + form.GetAttributeValue<string>("objecttypecode");
				cRMFormModel.Name = "FormName: " + form.GetAttributeValue<string>("name");

			}
			return cRMFormModel;

		}

	}
}