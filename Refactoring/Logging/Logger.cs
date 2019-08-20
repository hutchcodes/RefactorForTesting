using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Refactoring.Logging
{
    static class Logger 
    {
        public static void LogMessage(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
