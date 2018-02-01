using Travix.Services.BusinessLogic;
using Travix.Services.Contracts.Posts;

namespace Travix.Services.Posts.BusinessLogic.Services
{
	/// <summary>
	/// Service to operate over posts
	/// </summary>
	/// <seealso cref="Travix.Services.BusinessLogic.ICRUDOperationsService{Travix.Services.Contracts.Posts.Post, Travix.Services.DataAccess.Models.Post}" />
	public interface IPostsService : ICRUDOperationsService<Post, DataAccess.Models.Post>
	{
		//other specific methods goes there
	}
}
