namespace Franky.Playground.DataAccess.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using Franky.Playground.Constants.Enums;
	using Franky.Playground.DataAccess.Entities;

	internal sealed class Configuration : DbMigrationsConfiguration<PlaygroundContext>
	{
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(PlaygroundContext context)
		{
			context.Items.AddOrUpdate(p => p.Name, GetItems());
		}

		private static Item[] GetItems()
		{
			DateTime startDateTime = DateTime.Now.AddDays(-1000);
			
			Item[] items = new Item[1000];
			for (int i = 0; i < 1000; i++)
			{
				items[i] = new Item
					{
						Name = string.Format("Item {0:0000}", i + 1),
						DateTime = startDateTime.AddDays(i),
						Type = (ItemType)(i % 3),
						Rights = (Rights)(i % 8)
					};
			}

			return items;
		}
	}
}
