using Microsoft.Extensions.DependencyInjection;

namespace Travix.Services.Core.IoC
{
	//TODO: IoC/DI should be abstracted to not depend on MVC DI

	/// <summary>
	/// Container configurator
	/// </summary>
	public interface IContainerConfigurator
	{
		/// <summary>
		/// Configures DI dependencies with IoC-container.
		/// </summary>
		IContainerConfigurator Configure(IServiceCollection sevices);
	}
}
