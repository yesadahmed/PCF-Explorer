using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCf_Explorer_Sol.Models
{
	public class PCFModel
	{
		public string  name { get; set; }
		public bool IsFieldtype { get; set; }

		public bool DefaultMSControl { get; set; }
		public Guid solutionid { get; set; }

		public string clientjsonraw { get; set; }

		public Guid customcontrolid { get; set; }
		public string compatibledatatypes { get; set; }
		public DateTime createdon { get; set; }
		public string version { get; set; }
		public string createdbyName { get; set; }
		public string SolutionName { get; set; }

		public PCFClientJsonModel ClientJson { get; set; }
	}
}
