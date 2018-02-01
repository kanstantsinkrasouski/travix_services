using System;

namespace Travix.Services.DataAccess.Storages
{
	/// <summary>
	/// Factory for providing access to different storages
	/// </summary>
	public interface IStorageProvider
	{
		/// <summary>
		/// Gets the blog database factory.
		/// </summary>
		Func<IBlogDatabaseStorage> BlogDatabaseFactory { get; }
	}
}
