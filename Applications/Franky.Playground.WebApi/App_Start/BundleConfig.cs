namespace Franky.Playground.WebApi
{
	using System.Web.Optimization;

	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/app").Include(
				"~/Scripts/app/mainModule.js",
				"~/Scripts/app/mainConfig.js",
				"~/Scripts/app/factoryModule.js",
				"~/Scripts/app/dashboard/dashboardModule.js",
				"~/Scripts/app/dashboard/dashboardFactory.js",
				"~/Scripts/app/dashboard/weatherController.js",
				"~/Scripts/app/item/itemModule.js",
				"~/Scripts/app/item/itemListController.js",
				"~/Scripts/app/item/itemDetailController.js",
				"~/Scripts/app/item/itemFactory.js"
			));

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jQuery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
				"~/Scripts/angular.js", 
				"~/Scripts/angular-animate.js", 
				"~/Scripts/angular-resource.js", 
				"~/Scripts/angular-ui-router.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
				"~/Scripts/DataTables/jQuery.dataTables.js",
				"~/Scripts/DataTables/dataTables.bootstrap.js",
				"~/Scripts/DataTables/dataTables.responsive.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/content/bootstrap").Include(
				"~/Content/bootstrap.css",
				"~/Content/bootstrap-theme.css"));

			bundles.Add(new StyleBundle("~/content/datatables").Include(
				"~/Content/DataTables/css/dataTables.bootstrap.css"));
		}
	}
}