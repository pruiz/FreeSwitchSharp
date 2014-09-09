using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FreeSwitchSharp.Win64
{
	using FreeSwitchSharp.Native;

	public class Win64LibrariesBundle : INativeLibraryBundle
	{
		private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
		private static readonly string ResourcesPath = typeof(Win64LibrariesBundle).Namespace + ".Libs.";
		private static readonly List<INativeLibraryResource> _resources = new List<INativeLibraryResource>();

		static Win64LibrariesBundle()
		{
			foreach (var res in Assembly.GetManifestResourceNames())
			{
				if (res.StartsWith(ResourcesPath))
				{
					var fileName = res.Substring(ResourcesPath.Length);
					_resources.Add(new EmbeddedNativeLibraryResource(Assembly, res, fileName));
				}
			}
		}

		#region INativeLibraryBundle Members

		public bool SupportsCurrentPlatform
		{
			get
			{
				return Environment.OSVersion.Platform == PlatformID.Win32NT && NativeLibrariesManager.RunningIn64Bits;
			}
		}

		public IEnumerable<INativeLibraryResource> Resources
		{
			get { return _resources; }
		}

		#endregion
	}
}
