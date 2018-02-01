using Travix.Services.BusinessLogic.Common;
using Travix.Services.BusinessLogic.Conversion;
using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;

namespace Travix.Services.Posts.BusinessLogic.Services
{
	public class PostsService : CRUDOperationsService<Contracts.Posts.Post, Post>, IPostsService
	{
		public PostsService(IEntitiesConverter entitiesConverter, IRepository<Post> repository)
			: base(entitiesConverter, repository)
		{
		}
	}
}
