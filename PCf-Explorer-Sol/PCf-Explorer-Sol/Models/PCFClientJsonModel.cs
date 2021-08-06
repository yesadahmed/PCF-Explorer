using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCf_Explorer_Sol.Models
{

	public class Column
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public bool Hidden { get; set; }
		public bool Required { get; set; }
		public int Usage { get; set; }
		public string TypeGroup { get; set; }
	}
	public class Resource
	{
		public string Name { get; set; }
		public int LoadOrder { get; set; }
		public string LibraryName { get; set; }
		public string Type { get; set; }
		public string TypeGroup { get; set; }
	}

	public class DataSet
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string TypeGroup { get; set; }
		public bool InitialDataSetFetch { get; set; }
		public string CDSDataSetOptions { get; set; }
		public List<Column> Columns { get; set; }
	}

	public class Property
	{

		public List<Resource> Resources { get; set; }
		public List<DataSet> DataSets { get; set; }
		public List<PropertyDetail> Properties { get; set; }

	}

	public class PropertyDetail
	{
		public string Name { get; set; }
		public string TypeGroup { get; set; }
		public string Type { get; set; }
		public bool Hidden { get; set; }
		public bool Required { get; set; }
		public int Usage { get; set; }

	}

	public class PCFClientJsonModel
	{
		public string CustomControlId { get; set; }
		public string Name { get; set; }
		public string ConstructorName { get; set; }
		public string ControlMode { get; set; }
		public string DisplayName { get; set; }
		public string Namespace { get; set; }
		public bool IsVirtual { get; set; }
		public Property Properties { get; set; }
		public int VersionNumber { get; set; }
		public int OverallVersionNumber { get; set; }
		public string FullName { get; set; }
		public string createdbyName { get; set; }
		public string SolutionName { get; set; }

		public bool ismanaged { get; set; }
		public string friendlyname { get; set; }
		public string version { get; set; }

	}
}
