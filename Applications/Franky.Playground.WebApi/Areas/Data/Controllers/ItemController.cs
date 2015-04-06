namespace Franky.Playground.WebApi.Areas.Data.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Web.Http;
	using Franky.Playground.DataAccess.Entities;
	using Franky.Playground.DataAccess.Repositories;
	using Franky.Playground.Models.Item;

	public class ItemController : ApiController
	{
		private readonly ItemRepository itemRepository;

		public ItemController()
		{
			this.itemRepository = new ItemRepository();
		}

		// GET api/values
		public IEnumerable<ItemModel> Get()
		{
			IEnumerable<Item> items = this.itemRepository.GetAll();

			return items.Select(x => ToModel(x));
		}

		// GET api/values/5
		public ItemModel Get(long id)
		{
			Item item = this.itemRepository.GetById(id);
			if (item == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			return ToModel(item);
		}

		// POST api/values
		public void Post(ItemModel itemModel)
		{
			Item item = ToItem(itemModel);
			DatabaseStatus status = this.itemRepository.Insert(item);

			HandleDatabaseStatus(status);
		}

		// PUT api/values/5
		public void Put(long id, ItemModel itemModel)
		{
			if (id == itemModel.Id)
			{
				Item item = ToItem(itemModel);
				DatabaseStatus status = this.itemRepository.Update(item);

				HandleDatabaseStatus(status);
			}
			else
			{
				throw new HttpResponseException(HttpStatusCode.Forbidden);
			}
		}

		// DELETE api/values/5
		public void Delete(long id)
		{
			DatabaseStatus status = this.itemRepository.Delete(id);

			HandleDatabaseStatus(status);
		}

		private static void HandleDatabaseStatus(DatabaseStatus status)
		{
			switch (status)
			{
				case DatabaseStatus.Success:
					break;
				case DatabaseStatus.Failed:
					throw new HttpResponseException(HttpStatusCode.InternalServerError);
				case DatabaseStatus.NotFound:
					throw new HttpResponseException(HttpStatusCode.NotFound);
				default:
					throw new ArgumentOutOfRangeException("status");
			}
		}

		private static ItemModel ToModel(Item item)
		{
			return new ItemModel(item.Id, item.Name, item.Type, item.Rights, item.DateTime);
		}

		private static Item ToItem(ItemModel itemModel)
		{
			return new Item
				{
					Id = itemModel.Id, 
					Name = itemModel.Name, 
					Type = itemModel.Type, 
					Rights = itemModel.Rights, 
					DateTime = itemModel.DateTime
				};
		}
	}
}