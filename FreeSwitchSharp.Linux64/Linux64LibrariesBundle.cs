using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FreeSwitchSharp.Linux64
{
	using FreeSwitchSharp.Native;

	public class Linux64LibrariesBundle : INativeLibraryBundle
	{
		private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
		private static readonly string ResourcesPath = typeof(Linux64LibrariesBundle).Namespace + ".Libs.";
		private static readonly List<INativeLibraryResource> _resources = new List<INativeLibraryResource>();

		static Linux64LibrariesBundle()
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
				return Environment.OSVersion.Platform == PlatformID.Unix && NativeLibrariesManager.RunningIn64Bits;
			}
		}

		public IEnumerable<INativeLibraryResource> Resources
		{
			get { return _resources; }
		}

		#endregion
	}
}
