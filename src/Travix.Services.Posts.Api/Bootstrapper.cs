using Microsoft.Extensions.DependencyInjection;
using Travix.Services.Core.IoC;

namespace Travix.Services.Posts.Api
{
	internal class Bootstrapper : BootstrapperBase
	{
		internal Bootstrapper()
		{
		}

		protected override void Configure(IServiceCollection services)
		{
			new BusinessLogic.ContainerConfigurator().Configure(services);
			new Services.BusinessLogic.ContainerConfigurator().Configure(services);
			new Contracts.ContainerConfigurator().Configure(services);
			new Core.ContainerConfigurator().Configure(services);
			new DataAccess.ContainerConfigurator().Configure(services);
		}
	}
}
