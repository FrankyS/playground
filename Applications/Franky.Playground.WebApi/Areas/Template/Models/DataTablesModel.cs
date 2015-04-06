namespace Franky.Playground.WebApi.Areas.Template.Models
{
	using Newtonsoft.Json;

	public class DataTablesModel
	{
		public int Draw { get; set; }

		public int Start { get; set; }

		public int Length { get; set; }

		public Order[] Order { get; set; }

		public Column[] Columns { get; set; }

		public Search Search { get; set; }
	}

	public class Column
	{
		public string Data { get; set; }

		public string Name { get; set; }

		public Search Search { get; set; }
	}

	public class Search
	{
		public string Value { get; set; }
	}

	public class Order
	{
		public int Column { get; set; }

		[JsonProperty("Dir")]
		public string Dir { get; set; }
	}
}