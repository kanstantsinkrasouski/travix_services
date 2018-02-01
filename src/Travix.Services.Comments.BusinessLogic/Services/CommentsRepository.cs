using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;
using Travix.Services.DataAccess.Storages;

namespace Travix.Services.Comments.BusinessLogic.Services
{
	public sealed class CommentsRepository : Repository<Comment>
	{
		public CommentsRepository(IStorageProvider storageProvider)
			: base(storageProvider.BlogDatabaseFactory)
		{
		}
	}
}
