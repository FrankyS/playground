namespace Franky.Playground.WebApi.Controllers
{
	using System.Web.Mvc;

	public class ItemController : Controller
	{
		// GET: /Item/List
		public PartialViewResult List()
		{
			return this.PartialView();
		}

		// GET: /Item/Detail
		public PartialViewResult Detail()
		{
			return this.PartialView();
		}
	}
}
