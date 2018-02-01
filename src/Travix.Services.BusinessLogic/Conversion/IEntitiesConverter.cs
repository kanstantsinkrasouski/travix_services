namespace Travix.Services.BusinessLogic.Conversion
{
	/// <summary>
	/// Converts configured database models to web api contracts and back
	/// </summary>
	public interface IEntitiesConverter
	{
		/// <summary>
		/// Converts the specified model.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		TObject Convert<TModel, TObject>(TModel model);
		/// <summary>
		/// Convers the back.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="object">The object.</param>
		/// <returns></returns>
		TModel ConverBack<TObject, TModel>(TObject @object);
	}
}
