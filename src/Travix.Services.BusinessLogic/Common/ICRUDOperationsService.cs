using System.Collections.Generic;
using System.Threading.Tasks;
using Travix.Services.Contracts;

namespace Travix.Services.BusinessLogic
{
	/// <summary>
	/// Instances implementing this contract provides CRUD operations for specific types
	/// </summary>
	/// <typeparam name="TObject">The type of the object.</typeparam>
	/// <typeparam name="TModel">The type of the model.</typeparam>
	public interface ICRUDOperationsService<TObject, TModel> where TObject : class, IDataObject, new()
	{
		/// <summary>
		/// Gets all.
		/// </summary>
		List<TObject> Get();
		/// <summary>
		/// Gets all asynchronously.
		/// </summary>
		/// <returns></returns>
		Task<List<TObject>> GetAsync();
		/// <summary>
		/// Gets item by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		TObject Get(int id);
		/// <summary>
		/// Gets item by id asynchronously.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task<TObject> GetAsync(int id);
		/// <summary>
		/// Inserts the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Insert(TObject item);
		/// <summary>
		/// Inserts the specified item asynchronously.
		/// </summary>
		/// <param name="item">The item.</param>
		Task InsertAsync(TObject item);
		/// <summary>
		/// Updates the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Update(TObject item);
		/// <summary>
		/// Updates the specified item asynchronously.
		/// </summary>
		/// <param name="item">The item.</param>
		Task UpdateAsync(TObject item);
		/// <summary>
		/// Deletes the specified item by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		void Delete(int id);
		/// <summary>
		/// Deletes the specified item by id asynchronously.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task DeleteAsync(int id);
	}
}
