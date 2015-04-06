namespace Franky.Playground.Models.Item
{
	using System;
	using Franky.Playground.Constants.Enums;

	public class ItemModel : Model
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemModel"/> class.
		/// </summary>
		public ItemModel(long id, string name, ItemType type, Rights rights, DateTime dateTime)
		{
			this.Id = id;
			this.Name = name;
			this.Type = type;
			this.Rights = rights;
			this.DateTime = dateTime;
		}

		public string Name { get; set; }

		public ItemType Type { get; set; }

		public Rights Rights { get; set; }

		public DateTime DateTime { get; set; }
	}
}