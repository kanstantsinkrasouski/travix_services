using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;
using Travix.Services.DataAccess.Storages;

namespace Travix.Services.Posts.BusinessLogic.Services
{
	public sealed class PostsRepository : Repository<Post>
	{
		public PostsRepository(IStorageProvider storageProvider)
			: base(storageProvider.BlogDatabaseFactory)
		{
		}
	}
}
