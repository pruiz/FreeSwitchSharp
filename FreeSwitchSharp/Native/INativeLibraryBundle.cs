using System;
using System.IO;
using System.Collections.Generic;

namespace FreeSwitchSharp.Native
{
    /// <summary>
    /// A native library resource (ie. a file or dll which should be deployed as part of this bundle)
    /// </summary>
    public interface INativeLibraryResource
    {
        string FileName { get; }
        DateTime Date { get; }
        Stream GetResourceStream();
    }

    /// <summary>
    /// Bunclde containing native libraries for an specific platform.
    /// </summary>
    public interface INativeLibraryBundle
    {
        /// <summary>
        /// Gets a value indicating whether this instance can support current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can support current platform; otherwise, <c>false</c>.
        /// </value>
        bool SupportsCurrentPlatform { get; }
        /// <summary>
        /// Gets the bundle's resources.
        /// </summary>
        /// <value>
        /// The resources.
        /// </value>
        IEnumerable<INativeLibraryResource> Resources { get; }
    }
}
