using System.Collections.Generic;
using System.Threading.Tasks;
using Travix.Services.DataAccess.Models;

namespace Travix.Services.DataAccess.Repository
{
	/// <summary>
	/// Generic repository over <see cref="IEntity"/> derived entities
	/// </summary>
	public interface IRepository<T> where T : class, IEntity, new()
	{
		/// <summary>
		/// Gets all items.
		/// </summary>
		List<T> Get();
		/// <summary>
		/// Gets all items asynchronously.
		/// </summary>
		Task<List<T>> GetAsync();
		/// <summary>
		/// Gets item by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		T Get(int id);
		/// <summary>
		/// Gets item by id asynchronously.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task<T> GetAsync(int id);
		/// <summary>
		/// Inserts the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Insert(T item);
		/// <summary>
		/// Inserts the specified item asynchronously.
		/// </summary>
		/// <param name="item">The item.</param>
		Task InsertAsync(T item);
		/// <summary>
		/// Updates the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Update(T item);
		/// <summary>
		/// Updates the specified item asynchronously.
		/// </summary>
		/// <param name="item">The item.</param>
		Task UpdateAsync(T item);
		/// <summary>
		/// Deletes item by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		void Delete(int id);
		/// <summary>
		/// Deletes item by id asynchronously.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task DeleteAsync(int id);
	}
}
