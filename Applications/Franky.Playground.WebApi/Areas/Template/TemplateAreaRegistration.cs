namespace Franky.Playground.WebApi.Areas.Template
{
	using System.Web.Mvc;

	public class TemplateAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Template";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				name: "Template_Default", 
				url: "Template/{controller}/{action}/{id}", 
				defaults: new { action = "Index", id = UrlParameter.Optional }, 
				constraints: null,
				namespaces: new[] { "Franky.Playground.WebApi.Areas.Template.Controllers" });
		}
	}
}
