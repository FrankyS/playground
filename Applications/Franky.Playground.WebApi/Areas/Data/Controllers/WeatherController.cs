namespace Franky.Playground.WebApi.Areas.Data.Controllers
{
	using System.Web.Http;
	using Franky.Playground.Models.Dashboard;

	public class WeatherController : ApiController
	{
		// GET api/weather/
		public WeatherModel Get()
		{
			WeatherModel weatherModel = new WeatherModel();

			return weatherModel;
		}
	}
}