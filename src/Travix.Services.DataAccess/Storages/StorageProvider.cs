using System;

namespace Travix.Services.DataAccess.Storages
{
	public class StorageProvider : IStorageProvider
	{
		public Func<IBlogDatabaseStorage> BlogDatabaseFactory => () => new BlogDatabaseStorage();
	}
}
