namespace Franky.Playground.DataAccess.Repositories
{
	using System.Collections.Generic;
	using System.Data.Entity.Infrastructure;
	using System.Linq;
	using Franky.Playground.DataAccess.Entities;
	using log4net;

	public class ItemRepository
	{
		private readonly ILog logger = LogManager.GetLogger(typeof(ItemRepository));
		private readonly PlaygroundContext context = new PlaygroundContext();

		public IEnumerable<Item> GetAll()
		{
			return this.context.Items
				.Take(50)
				.ToList();
		}

		public IEnumerable<Item> GetFiltered(int skip, int take, string order, string filter)
		{
			IQueryable<Item> queryable = this.context.Items;

			if (!string.IsNullOrEmpty(filter))
			{
				queryable = queryable.Where(x => x.Name.Contains(filter));
			}

			queryable = string.Equals(order, "asc")
				? queryable.OrderBy(x => x.Id)
				: queryable.OrderByDescending(x => x.Id);

			if (take > 100)
			{
				take = 100;
			}

			queryable = queryable
				.Skip(skip)
				.Take(take);

			return queryable
				.ToList();
		}

		public Item GetById(long id)
		{
			return this.context.Items.Find(id);
		}

		public DatabaseStatus Insert(Item item)
		{
			DatabaseStatus status = DatabaseStatus.Failed;

			if (item.Id == 0)
			{
				try
				{
					this.context.Items.Add(item);
					this.context.SaveChanges();

					status = DatabaseStatus.Success;
				}
				catch (DbUpdateException ex)
				{
					this.logger.Error(ex.Message, ex);
				}
			}

			return status;
		}

		public DatabaseStatus Update(Item item)
		{
			DatabaseStatus status = DatabaseStatus.NotFound;

			Item storedItem = this.GetById(item.Id);
			if (storedItem != null)
			{
				try
				{
					DbEntityEntry<Item> entityEntry = this.context.Entry(storedItem);
					entityEntry.CurrentValues.SetValues(item);
					this.context.SaveChanges();

					status = DatabaseStatus.Success;
				}
				catch (DbUpdateException ex)
				{
					this.logger.Error(ex.Message, ex);
					status = DatabaseStatus.Failed;
				}
			}

			return status;
		}

		public DatabaseStatus Delete(long id)
		{
			DatabaseStatus status = DatabaseStatus.NotFound;

			Item item = this.GetById(id);
			if (item != null)
			{
				try
				{
					this.context.Items.Remove(item);
					this.context.SaveChanges();

					status = DatabaseStatus.Success;
				}
				catch (DbUpdateException ex)
				{
					this.logger.Error(ex.Message, ex);
					status = DatabaseStatus.Failed;
				}
			}

			return status;
		}
	}

	public enum DatabaseStatus
	{
		Success, 

		Failed, 

		NotFound
	}
}