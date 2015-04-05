namespace Franky.Playground.WebApi.Models
{
	public class ValueModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ValueModel"/> class.
		/// </summary>
		public ValueModel(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; set; }

		public string Name { get; set; }
	}
}