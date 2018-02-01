using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Travix.Services.BusinessLogic.Validation
{
	public class ValidationService : IValidationService
	{
		public bool ValidateId(int id, out object error)
		{
			error = null;

			if (id <= 0)
			{
				error = Resources.Validation.Id_Invalid;
				return false;
			}

			return true;
		}

		public bool ValidateModel(ModelStateDictionary modelState, out object error)
		{
			error = modelState;
			return modelState.IsValid;
		}
	}
}
