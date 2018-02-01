namespace Travix.Services.Contracts
{
	/// <summary>
	/// Data object contract identified by id
	/// </summary>
	public interface IDataObject
	{
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		int Id { get; }
	}
}
