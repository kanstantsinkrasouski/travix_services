using Microsoft.Extensions.DependencyInjection;
using Travix.Services.Core.IoC;
using Travix.Services.DataAccess.Repository;
using Travix.Services.DataAccess.Storages;

namespace Travix.Services.DataAccess
{
	public sealed class ContainerConfigurator : IContainerConfigurator
	{
		public IContainerConfigurator Configure(IServiceCollection sevices)
		{
			sevices.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			sevices.AddSingleton<IStorageProvider, StorageProvider>();
			return this;
		}
	}
}
