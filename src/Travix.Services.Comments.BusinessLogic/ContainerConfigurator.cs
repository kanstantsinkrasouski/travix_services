using Microsoft.Extensions.DependencyInjection;
using Travix.Services.Comments.BusinessLogic.Services;
using Travix.Services.Core.IoC;
using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;

namespace Travix.Services.Comments.BusinessLogic
{
	public sealed class ContainerConfigurator : IContainerConfigurator
	{
		public IContainerConfigurator Configure(IServiceCollection services)
		{
			services.AddSingleton<IRepository<Comment>, CommentsRepository>();
			services.AddTransient<ICommentsService, CommentsService>();
			return this;
		}
	}
}
