namespace Franky.Playground.WebApi
{
	using System.Web.Optimization;

	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
				"~/Scripts/angular.js", 
				"~/Scripts/angular-animate.js", 
				"~/Scripts/angular-resource.js", 
				"~/Scripts/angular-ui-router.js"));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
				"~/Scripts/app/app.js",
				"~/Scripts/app/Routes.js",
				"~/Scripts/app/ItemControllers.js",
				"~/Scripts/app/ItemServices.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/site.css",
				"~/Content/uiview.css"));
		}
	}
}