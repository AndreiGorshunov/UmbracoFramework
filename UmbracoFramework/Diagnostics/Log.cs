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

        public static void Info(Type type, string message, Exception ex = null)
        {
            ILog log = LogManager.GetLogger(type);
            if (ex != null)
            {
                log.Info(message, ex);
            }
            else
            {
                log.Info(message);
            }
        }
    }
}
