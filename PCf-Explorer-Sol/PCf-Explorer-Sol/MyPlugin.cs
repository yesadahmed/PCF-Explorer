using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace PCf_Explorer_Sol
{
	// Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
	// To generate Base64 string for Images below, you can use https://www.base64-image.de/
	[Export(typeof(IXrmToolBoxPlugin)),
		ExportMetadata("Name", "PCF-Explorer"),
		ExportMetadata("Description", "A tool to explore PCF control dependencies (properties, dataset, resources, entities and solution). Works with OAUTH/Certifcate Connection."),
		// Please specify the base64 content of a 32x32 pixels image
		ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAetJREFUWEfNlztOw0AQhnd8gUTpAPEqcEQFBdCDCJFSUUVCSkONRIEdBFS0EJsbUHKCtDRwi4QCB4m0KBxgB9nC0Xq9T8copIqSmfm/3X92vAYy5w/MWZ8UAvBcfwwACxl4JONg2FuyXZAxgOf6FACM4pEghoPAMYHRFvRdPyIAqybFcjEUP4K3QJmrBPDrXSwkzCUFg55UR/pHWeIpiwxCCFC2uAoiBzCT5xq/KNLoYRius2F5gJJ8l7HwVmQAbI4aL7B3vFtt37UnJvaxEBkAk2TRyhpnh6R53kxqmdQoHYAtWBhAOF6Z5cpEbH+PSyLSKPxtxqkFMnLR+U1jZeLbO1uVzlPnm7WLr5/mSgFUwnHh5ulRtXHVmKh852uwEEoANrG7eYlI8xM5jdF5rrNIuAMq8njFKnHZyNVb4HY/CZDF1LeDk/1K67Y19bF/3/96eXytysRryzVy83yt7amkCQmOwkGwFn+3mgO2x81kGhYC0Pmue4RLB5FX9ykQ8a3HtOl04mwP5SwwHaUmIibbLwbY8EfEgZVZRGS5iCQKhz314/gvd0F0RP/nlSzdwlm7XXcfFPYA79+F67074CRDw/Yj8pyvoX0vKLobqqs4C2EMwCZ5rhcBOJkXDna82uxUIQAbAV3s3AF+AOWZ9iHyF9O3AAAAAElFTkSuQmCC"),
		// Please specify the base64 content of a 80x80 pixels image
		ExportMetadata("BigImageBase64", "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"),
		ExportMetadata("BackgroundColor", "#f0f8ff"),
		ExportMetadata("PrimaryFontColor", "Black"),
		ExportMetadata("SecondaryFontColor", "Gray")]
	public class MyPlugin : PluginBase
	{
		public override IXrmToolBoxPluginControl GetControl()
		{
			return new MyPluginControl();
		}

		/// <summary>
		/// Constructor 
		/// </summary>
		public MyPlugin()
		{
			// If you have external assemblies that you need to load, uncomment the following to 
			// hook into the event that will fire when an Assembly fails to resolve
			// AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
		}

		/// <summary>
		/// Event fired by CLR when an assembly reference fails to load
		/// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
		/// For example, a folder named Sample.XrmToolBox.MyPlugin 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
		{
			Assembly loadAssembly = null;
			Assembly currAssembly = Assembly.GetExecutingAssembly();

			// base name of the assembly that failed to resolve
			var argName = args.Name.Substring(0, args.Name.IndexOf(","));

			// check to see if the failing assembly is one that we reference.
			List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
			var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

			// if the current unresolved assembly is referenced by our plugin, attempt to load
			if (refAssembly != null)
			{
				// load from the path to this plugin assembly, not host executable
				string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
				string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
				dir = Path.Combine(dir, folder);

				var assmbPath = Path.Combine(dir, $"{argName}.dll");

				if (File.Exists(assmbPath))
				{
					loadAssembly = Assembly.LoadFrom(assmbPath);
				}
				else
				{
					throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
				}
			}

			return loadAssembly;
		}
	}
}