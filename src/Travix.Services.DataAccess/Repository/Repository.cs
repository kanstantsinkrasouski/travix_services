using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Storages;

namespace Travix.Services.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class, IEntity, new()
	{
		private readonly Func<IStorage> _storageFactory;

		public Repository(Func<IStorage> storageFactory)
		{
			_storageFactory = storageFactory;
		}

		private TResult Execute<TResult>(Func<IStorage, TResult> execute)
		{
			using (IStorage storage = _storageFactory.Invoke())
			{
				return execute(storage);
			}
		}

		public List<T> Get()
		{
			return Execute((storage) => storage.GetAll<T>().ToList());
		}

		public Task<List<T>> GetAsync()
		{
			return Execute((storage) => storage.GetAll<T>().ToListAsync());
		}

		public T Get(int id)
		{
			return Execute((storage) => storage.GetAll<T>().FirstOrDefault(t => t.Id == id));
		}

		public Task<T> GetAsync(int id)
		{
			return Execute((storage) => storage.GetAll<T>().FirstOrDefaultAsync(t => t.Id == id));
		}

		public void Insert(T item)
		{
			Execute((storage) =>
			{
				T newItem = storage.Insert(item);
				storage.Save();
				return newItem;
			});
		}

		public Task InsertAsync(T item)
		{
			return Execute((storage) =>
			{
				T newItem = storage.Insert(item);
				return storage.SaveAsync();
			});
		}

		public void Update(T item)
		{
			Execute((storage) =>
			{
				storage.Update(item);
				storage.Save();
				return item;
			});
		}

		public Task UpdateAsync(T item)
		{
			return Execute((storage) =>
			{
				storage.Update(item);
				return storage.SaveAsync();
			});
		}

		public void Delete(int id)
		{
			Execute((storage) =>
			{
				T item = Get(id);
				storage.Delete(item);
				storage.Save();
				return item;
			});
		}

		public Task DeleteAsync(int id)
		{
			return Execute(async (storage) =>
			{
				T item = await GetAsync(id);
				storage.Delete(item);
				return storage.SaveAsync();
			});
		}
	}
}
