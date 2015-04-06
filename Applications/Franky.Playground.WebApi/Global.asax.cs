namespace Franky.Playground.WebApi
{
	using System.Web;
	using System.Web.Http;
	using System.Web.Mvc;
	using System.Web.Optimization;
	using System.Web.Routing;
	using log4net;
	using log4net.Config;
	using log4net.Repository;

	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class WebApiApplication : HttpApplication
	{
		private readonly ILog logger = LogManager.GetLogger(typeof(WebApiApplication));

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			XmlConfigurator.Configure();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Application_BeginRequest()
		{
			logger.Debug(this.Request.Url.AbsoluteUri);
		}
	}
}