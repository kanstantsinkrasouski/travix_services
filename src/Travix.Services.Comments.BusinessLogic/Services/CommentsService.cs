using Travix.Services.BusinessLogic.Common;
using Travix.Services.BusinessLogic.Conversion;
using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;

namespace Travix.Services.Comments.BusinessLogic
{
	public sealed class CommentsService : CRUDOperationsService<Contracts.Comments.Comment, Comment>, ICommentsService
	{
		public CommentsService(IEntitiesConverter entitiesConverter, IRepository<Comment> repository)
			: base(entitiesConverter, repository)
		{
		}
	}
}
