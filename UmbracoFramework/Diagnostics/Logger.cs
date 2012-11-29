using System;
using log4net;
using log4net.Config;

namespace UmbracoFramework.Diagnostics
{
    public class Logger : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Logger));

        public Logger()
        {
            InitializeComponent();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Application start-up code goes here.
            XmlConfigurator.Configure();

            Log.Debug("Fired up logger in application_start");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Log.Debug("closed logger in application_end");
            LogManager.Shutdown();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            Log.Error("Unhandled exception", Context.Error);
        }

        private void InitializeComponent()
        {

        }
    }
}
