using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Newtonsoft.Json;
using PCf_Explorer_Sol.Models;
using System;
using System.Collections.Generic;
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
					"compatibledatatypes", "createdon", "version", "createdby","name");

				LinkEntity EntityB = new LinkEntity("customcontrol", "solution", "solutionid", "solutionid", JoinOperator.Inner);
				EntityB.Columns = new ColumnSet("uniquename");
				EntityB.EntityAlias = "EntitySol";

				query.LinkEntities.Add(EntityB);

				// Join Operator can be change if there is chance of Null values in the Lookup. Use Left Outer join
				LinkEntity EntityC = new LinkEntity("customcontrol", "systemuser", "createdby", "systemuserid", JoinOperator.Inner);
				EntityC.Columns = new ColumnSet("fullname");
				EntityC.EntityAlias = "EntityUser";
				query.LinkEntities.Add(EntityC);

				query.Criteria.Conditions.Add(new ConditionExpression("compatibledatatypes", ConditionOperator.NotEqual, ""));

				var result = crmservice.RetrieveMultiple(query);

				foreach (var entity in result.Entities)
				{
					pCFModel = new PCFModel();
					pCFModel.clientjsonraw = entity.GetAttributeValue<string>("clientjson");

					if (!string.IsNullOrWhiteSpace(pCFModel.clientjsonraw))
						pCFModel.ClientJson = JsonConvert.DeserializeObject<PCFClientJsonModel>(pCFModel.clientjsonraw);

					pCFModel.name= entity.GetAttributeValue<string>("name");

					pCFModel.compatibledatatypes = entity.GetAttributeValue<string>("compatibledatatypes");
					if (pCFModel.compatibledatatypes.ToLower().Equals("grid"))
						pCFModel.IsFieldtype = false;
					else
						pCFModel.IsFieldtype = true;

					var createdby = entity.GetAttributeValue<AliasedValue>("EntityUser.fullname");
					if (createdby != null)
						pCFModel.createdbyName = Convert.ToString(createdby.Value);

					pCFModel.createdon = entity.GetAttributeValue<DateTime>("createdon");
					pCFModel.customcontrolid = entity.Id;
					pCFModel.solutionid = entity.GetAttributeValue<Guid>("solutionid");
					var solName = entity.GetAttributeValue<AliasedValue>("EntitySol.uniquename");
					if (solName != null)
						pCFModel.SolutionName = Convert.ToString(solName.Value);
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


		#endregion
	}
}
