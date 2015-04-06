namespace Franky.Playground.DataAccess.Entities
{
	using System;
	using Franky.Playground.Constants.Enums;

	public class Item : Entity
	{
		public string Name { get; set; }

		public ItemType Type { get; set; }

		public Rights Rights { get; set; }

		public DateTime DateTime { get; set; }
	}
}
