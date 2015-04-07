namespace Franky.Playground.DataAccess.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.Linq;
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
			const int Amount = 100000;
			const int BatchSize = 1000;

			List<Item> items = GetItems(Amount);
			for (int i = 0; i < Amount; i += BatchSize)
			{
				Item[] batchItems = items
					.Skip(i)
					.Take(BatchSize)
					.ToArray();
				context.Items.AddOrUpdate(p => p.Name, batchItems);
				context.SaveChanges();
			}
		}

		private static List<Item> GetItems(int amount)
		{
			DateTime startDateTime = DateTime.Now.AddDays(-1 * amount);

			List<Item> items = new List<Item>(amount);
			for (int i = 0; i < amount; i++)
			{
				items.Add(new Item
					{
						Name = string.Format("Item {0:0000}", i + 1),
						DateTime = startDateTime.AddDays(i),
						Type = (ItemType)(i % 3),
						Rights = (Rights)(i % 8)
					});
			}

			return items;
		}
	}
}
