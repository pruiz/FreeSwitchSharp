using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FreeSwitchSharp
{
    internal static class SystemCalls
    {
        #region Linux/Libc P/Invokes
        [DllImport("libc")]
        private static extern int uname(IntPtr buf);
        #endregion

        #region Linux/Libc Call Wrappers
        private static object _OsNameLock = new object();
        private static string _OsName = null;

        private static string GetOsNameInternal()
        {
            if (!string.IsNullOrEmpty(_OsName))
                return _OsName;

            if (Environment.OSVersion.Platform != PlatformID.Unix
                    && Environment.OSVersion.Platform != PlatformID.MacOSX)
            {
                return Environment.OSVersion.Platform.ToString();
            }

            IntPtr buf = IntPtr.Zero;
            try
            {
                buf = Marshal.AllocHGlobal(8192);
                // This is a hacktastic way of getting sysname from uname ()
                if (uname(buf) == 0)
                {
                    return Marshal.PtrToStringAnsi(buf);
                }
            }
            catch { }
            finally
            {
                if (buf != IntPtr.Zero) Marshal.FreeHGlobal(buf);
            }

            return null;
        }

        public static string GetOsName()
        {
            lock (_OsNameLock)
            {
                if (_OsName == null)
                    _OsName = GetOsNameInternal();

                return _OsName;
            }
        }
        #endregion
    }
}
