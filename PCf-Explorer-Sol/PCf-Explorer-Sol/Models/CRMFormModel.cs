using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCf_Explorer_Sol.Models
{
	public class CRMFormModel
	{
		public string Name { get; set; }
		public string entity { get; set; }
		public Guid FormId { get; set; }
	}


	public class ListGroupDisplyModel
	{
		public string GroupName { get; set; }
		public List<CRMFormModel> Forms { get; set; }
	}


}
