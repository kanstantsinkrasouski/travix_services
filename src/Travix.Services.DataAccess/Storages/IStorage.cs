using System;
using System.Linq;
using System.Threading.Tasks;

namespace Travix.Services.DataAccess.Storages
{
	/// <summary>
	/// Common contract for storage implementations
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public interface IStorage : IDisposable
	{
		/// <summary>
		/// Gets all items from storage.
		/// </summary>
		IQueryable<T> GetAll<T>() where T : class;
		/// <summary>
		/// Inserts the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns>The items inserted.</returns>
		T Insert<T>(T item) where T : class;
		/// <summary>
		/// Updates the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Update<T>(T item) where T : class;
		/// <summary>
		/// Deletes the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Delete<T>(T item) where T : class;

		/// <summary>
		/// Saves changes applied to storage.
		/// </summary>
		void Save();
		/// <summary>
		/// Saves changes applied to storage asynchronously.
		/// </summary>
		Task SaveAsync();
	}
}
