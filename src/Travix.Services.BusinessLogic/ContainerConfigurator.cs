using Microsoft.Extensions.DependencyInjection;
using Travix.Services.BusinessLogic.Conversion;
using Travix.Services.BusinessLogic.Validation;
using Travix.Services.Core.IoC;

namespace Travix.Services.BusinessLogic
{
	public sealed class ContainerConfigurator : IContainerConfigurator
	{
		public IContainerConfigurator Configure(IServiceCollection services)
		{
			services.AddScoped<IEntitiesConverter, EntitiesConverter>();
			services.AddSingleton<IValidationService, ValidationService>();
			return this;
		}
	}
}
