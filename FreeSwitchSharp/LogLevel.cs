using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSwitchSharp
{
    [Flags]
    public enum LogLevel
    {
        EMERG = 0,
        ALERT,
        CRIT,
        ERROR,
        WARNING,
        NOTICE,
        INFO,
        DEBUG
    }
}
