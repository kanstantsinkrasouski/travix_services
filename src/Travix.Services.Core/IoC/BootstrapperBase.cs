using Microsoft.Extensions.DependencyInjection;

namespace Travix.Services.Core.IoC
{
	public abstract class BootstrapperBase : IBootstrapper
	{
		protected abstract void Configure(IServiceCollection services);

		public void Run(IServiceCollection services)
		{
			Configure(services);
			//other specific initialization logic goes here
		}
	}
}
