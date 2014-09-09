using System;
using System.IO;
using System.Reflection;

namespace FreeSwitchSharp.Native
{
    /// <summary>
    /// INativeLibraryResource implementation using an embedded assembly resources internally.
    /// </summary>
    public class EmbeddedNativeLibraryResource : INativeLibraryResource
    {
        private Assembly _assembly = null;
        private string _resource = null;

        public DateTime Date { get { return File.GetLastWriteTime(_assembly.Location); } }
        public string FileName { get; private set; }

        public EmbeddedNativeLibraryResource(Assembly assembly, string resource, string filename)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            if (string.IsNullOrWhiteSpace(resource)) throw new ArgumentNullException("resource");
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException("filename");

            _assembly = assembly;
            _resource = resource;
            FileName = filename;
        }

        public Stream GetResourceStream()
        {
            return _assembly.GetManifestResourceStream(_resource);
        }
    }
}
