namespace VeloEventsManager
{
	using System;
	using System.Web;
	using System.Web.Optimization;
	using System.Web.Routing;

	using VeloEventsManager.App_Start;

	public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
			DatabaseConfig.Initialize();

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}