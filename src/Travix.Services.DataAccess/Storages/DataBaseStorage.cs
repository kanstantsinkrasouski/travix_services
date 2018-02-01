using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace Travix.Services.DataAccess.Storages
{
	public class DataBaseStorage : DbContext, IStorage
	{
		private readonly string _databasePath;

		public DataBaseStorage(string databasePath)
		{
			_databasePath = databasePath;
			Database.EnsureCreated();
		}

		protected string Path => _databasePath;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = string.Format("Data Source={0}", _databasePath);
			optionsBuilder.UseSqlite(connectionString);
		}

		public void Delete<T>(T item) where T : class
		{
			EntityEntry<T> entry = Entry<T>(item);
			entry.State = EntityState.Deleted;
		}

		public IQueryable<T> GetAll<T>() where T : class
		{
			return Set<T>().AsNoTracking();
		}

		public T Insert<T>(T item) where T : class
		{
			EntityEntry<T> itemEntry = Entry<T>(item);
			Set<T>().Add(item);
			return itemEntry.Entity;
		}

		public void Save()
		{
			SaveChanges(true);
		}

		public Task SaveAsync()
		{
			return SaveChangesAsync(true);
		}

		void IStorage.Update<T>(T item)
		{
			EntityEntry<T> itemEntry = Entry<T>(item);
			itemEntry.State = EntityState.Modified;
		}
	}
}
