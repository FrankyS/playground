namespace Franky.Playground.WebApi.Areas.Template.Controllers
{
	using System.Web.Mvc;

	public class HomeController : Controller
	{
		public PartialViewResult About()
		{
			return this.PartialView();
		}
	}
}
