namespace Franky.Playground.WebApi.Areas.Template.Controllers
{
	using System.Web.Mvc;

	public class DashboardController : Controller
	{
		public PartialViewResult Index()
		{
			return this.PartialView();
		}

		public PartialViewResult Weather()
		{
			return this.PartialView();
		}

		public PartialViewResult Calendar()
		{
			return this.PartialView();
		}
	}
}