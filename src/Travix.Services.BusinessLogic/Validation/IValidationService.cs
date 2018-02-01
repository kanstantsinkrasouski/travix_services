using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Travix.Services.BusinessLogic.Validation
{
	/// <summary>
	/// Provides validation capabilities for common types of data models 
	/// </summary>
	public interface IValidationService
	{
		/// <summary>
		/// Validates the identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="error">The error.</param>
		bool ValidateId(int id, out object error);
		/// <summary>
		/// Validates the model.
		/// </summary>
		/// <param name="modelState">State of the model.</param>
		/// <param name="error">The error.</param>
		bool ValidateModel(ModelStateDictionary modelState, out object error);
	}
}
