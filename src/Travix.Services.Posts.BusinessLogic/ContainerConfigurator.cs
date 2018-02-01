using Microsoft.Extensions.DependencyInjection;
using Travix.Services.Core.IoC;
using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;
using Travix.Services.Posts.BusinessLogic.Services;

namespace Travix.Services.Posts.BusinessLogic
{
	public sealed class ContainerConfigurator : IContainerConfigurator
	{
		public IContainerConfigurator Configure(IServiceCollection services)
		{
			services.AddSingleton<IRepository<Post>, PostsRepository>();
			services.AddTransient<IPostsService, PostsService>();
			return this;
		}
	}
}
