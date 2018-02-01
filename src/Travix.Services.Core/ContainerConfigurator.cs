using Microsoft.Extensions.DependencyInjection;
using Travix.Services.Core.IoC;

namespace Travix.Services.Core
{
	public sealed class ContainerConfigurator : IContainerConfigurator
	{
		public IContainerConfigurator Configure(IServiceCollection sevices)
		{
			return this;
		}
	}
}
