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
			ListViewItem item = null;

			var groupTrg = new ListViewGroup($"PCF Controls");
			listViewPCF.Groups.Add(groupTrg);
			// Initialize the tile size.
			listViewPCF.TileSize = new Size(550, 43);
			ImageList myImageList = new ImageList();
			myImageList.ColorDepth = ColorDepth.Depth32Bit;
			myImageList.Images.Add(
			  LoadImage("https://yt3.ggpht.com/ytc/AAUvwnhFJfURr8yQoGO1YMAOhLWIrh5cHd4OVjMKZvTTWA=s68-c-k-c0x00ffffff-no-rj"));
			myImageList.ImageSize = new Size(32, 32);
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
			
			//this.Size = new System.Drawing.Size(430, 330);
			//this.Text = "ListView Tiling Example";

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
		#endregion
	}
}