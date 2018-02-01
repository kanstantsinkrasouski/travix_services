using Travix.Services.BusinessLogic;

namespace Travix.Services.Comments.BusinessLogic
{
	/// <summary>
	/// Service to operate over comments
	/// </summary>
	/// <seealso cref="Travix.Services.BusinessLogic.ICRUDOperationsService{Travix.Services.Contracts.Comments.Comment, Travix.Services.DataAccess.Models.Comment}" />
	public interface ICommentsService : ICRUDOperationsService<Contracts.Comments.Comment, DataAccess.Models.Comment>
	{
		//other specific methods goes there
	}
}
