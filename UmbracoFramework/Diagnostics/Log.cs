using System;
using log4net;

namespace UmbracoFramework.Diagnostics
{
    public static class Log
    {
        public static void Error(Type type, Exception ex, string message = null)
        {
            ILog log = LogManager.GetLogger(type);
            log.Error(message, ex);
        }
    }
}
