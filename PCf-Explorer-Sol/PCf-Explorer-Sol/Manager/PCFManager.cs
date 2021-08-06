using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCf_Explorer_Sol.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCf_Explorer_Sol.Manager
{
	public class PCFManager
	{
		#region data members
		static CrmServiceClient crmservice;
		#endregion

		#region constructor

		public PCFManager(CrmServiceClient _crmservice)
		{
			crmservice = _crmservice;
		}

		#endregion


		#region Public funtions
		public List<PCFModel> GetPCfControls()
		{
			List<PCFModel> lst = new List<PCFModel>();
			try
			{

				PCFModel pCFModel = null;
				QueryExpression query = new QueryExpression("customcontrol");
				query.ColumnSet = new ColumnSet("solutionid", "clientjson", "customcontrolid",
					"compatibledatatypes", "createdon", "version", "createdby", "name");

				LinkEntity EntityB = new LinkEntity("customcontrol", "solution", "solutionid", "solutionid", JoinOperator.Inner);
				EntityB.Columns = new ColumnSet("uniquename", "ismanaged", "friendlyname", "version");
				EntityB.EntityAlias = "EntitySol";

				query.LinkEntities.Add(EntityB);

				// Join Operator can be change if there is chance of Null values in the Lookup. Use Left Outer join
				LinkEntity EntityC = new LinkEntity("customcontrol", "systemuser", "createdby", "systemuserid", JoinOperator.Inner);
				EntityC.Columns = new ColumnSet("fullname");
				EntityC.EntityAlias = "EntityUser";
				query.LinkEntities.Add(EntityC);

				query.Criteria.Conditions.Add(new ConditionExpression("compatibledatatypes", ConditionOperator.NotEqual, ""));
				query.Orders.Add(new Microsoft.Xrm.Sdk.Query.OrderExpression("createdon", Microsoft.Xrm.Sdk.Query.OrderType.Descending));


				var result = crmservice.RetrieveMultiple(query);

				foreach (var entity in result.Entities)
				{
					pCFModel = new PCFModel();
					pCFModel.clientjsonraw = entity.GetAttributeValue<string>("clientjson");

					if (!string.IsNullOrWhiteSpace(pCFModel.clientjsonraw))
					{
						pCFModel.ClientJson = JsonConvert.DeserializeObject<PCFClientJsonModel>(pCFModel.clientjsonraw);
						
						var createdby = entity.GetAttributeValue<AliasedValue>("EntityUser.fullname");
						if (createdby != null)
							pCFModel.createdbyName = Convert.ToString(createdby.Value);

						if (pCFModel.ClientJson != null)
						{
							
							var solName = entity.GetAttributeValue<AliasedValue>("EntitySol.uniquename");
							var ismanaged = entity.GetAttributeValue<AliasedValue>("EntitySol.ismanaged");
							var friendlyname = entity.GetAttributeValue<AliasedValue>("EntitySol.friendlyname");
							var version = entity.GetAttributeValue<AliasedValue>("EntitySol.version");


							if (solName != null)
								pCFModel.SolutionName = Convert.ToString(solName.Value);

							if (ismanaged != null)
								pCFModel.ClientJson.ismanaged = Convert.ToBoolean(ismanaged.Value);

							if (friendlyname != null)
								pCFModel.ClientJson.friendlyname = Convert.ToString(friendlyname.Value);


							if (version != null)
								pCFModel.ClientJson.version = Convert.ToString(version.Value);

							pCFModel.ClientJson.SolutionName = pCFModel.SolutionName;
							pCFModel.ClientJson.createdbyName = pCFModel.createdbyName;


						}

					}



					pCFModel.name = entity.GetAttributeValue<string>("name");

					pCFModel.DefaultMSControl = IsMicrosftControl(pCFModel.name);


					pCFModel.compatibledatatypes = entity.GetAttributeValue<string>("compatibledatatypes");
					if (pCFModel.compatibledatatypes.ToLower().Equals("grid"))
						pCFModel.IsFieldtype = false;
					else
						pCFModel.IsFieldtype = true;



					pCFModel.createdon = entity.GetAttributeValue<DateTime>("createdon");
					pCFModel.customcontrolid = entity.Id;
					pCFModel.solutionid = entity.GetAttributeValue<Guid>("solutionid");




					pCFModel.version = entity.GetAttributeValue<string>("version");
					lst.Add(pCFModel);
				}

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return lst;
		}
		#endregion

		#region Private Helpers

		bool IsMicrosftControl(string name)
		{
			bool result = false;

			if (name.Contains("MscrmControls"))
				result = true;
			else if (name.Contains("MscrmControls."))
				result = true;
			else if (name.Contains("msdyn_"))
				result = true;
			else if (name.Contains("msfp_"))
				result = true;
			else if (name.Contains("msfp_MscrmControls"))
				result = true;
			else if (name.Contains("MsdynmktControls"))
				result = true;
			else if (name.Contains("MsdynmktControls."))
				result = true;
			else if (name.Contains("LinkedInExtensionControls.JQueryHierarchy.JQueryHierarchyControl"))
				result = true;
			else if (name.Contains("PlaybookControls.ActivityForm.PBActivityControl"))
				result = true;
			else if (name.Contains("Intelligence.BusinessCardReaderControl.BusinessCardReader"))
				result = true;
			else if (name.Contains("ForecastingControls.FieldControls.ParticipatingRecordControl"))
				result = true;
			else if (name.Contains("MicrosoftDynamicsScheduling"))
				result = true;
			else if (name.Contains("MicrosoftDynamicsFPS"))
				result = true;


			return result;

		}
		#endregion
	}
}
