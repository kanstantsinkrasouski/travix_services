using Microsoft.Extensions.DependencyInjection;

namespace Travix.Services.Core.IoC
{
	/// <summary>
	/// Bootstrapper for API service
	/// </summary>
	public interface IBootstrapper
	{
		/// <summary>
		/// Initializes API service
		/// </summary>
		/// <param name="sevices">DI services</param>
		void Run(IServiceCollection sevices);
	}
}
