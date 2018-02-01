namespace Travix.Services.DataAccess.Models
{
	/// <summary>
	/// Database entity 
	/// </summary>
	public interface IEntity
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
