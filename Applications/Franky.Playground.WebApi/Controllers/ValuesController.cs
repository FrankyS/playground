namespace Franky.Playground.WebApi.Controllers
{
	using System.Collections.Generic;
	using System.Web.Http;
	using Franky.Playground.WebApi.Models;

	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<ValueModel> Get()
		{
			return new[] { new ValueModel(1, "Value 1"), new ValueModel(2, "Value 2") };
		}

		// GET api/values/5
		public ValueModel Get(int id)
		{
			return new ValueModel(id, "Value " + id);
		}

		// POST api/values
		public void Post(ValueModel value)
		{
		}

		// PUT api/values/5
		public void Put(int id, ValueModel value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}