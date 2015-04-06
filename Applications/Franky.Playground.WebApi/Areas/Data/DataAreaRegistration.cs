namespace Franky.Playground.WebApi.Areas.Data
{
	using System.Web.Http;
	using System.Web.Mvc;

	public class DataAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Data";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.Routes.MapHttpRoute(
				name: "Data_DefaultApi", 
				routeTemplate: "Data/{controller}/{id}", 
				defaults: new { id = RouteParameter.Optional }, 
				constraints: null);
		}
	}
}
