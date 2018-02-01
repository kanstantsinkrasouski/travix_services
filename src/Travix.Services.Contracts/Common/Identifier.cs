using System.Runtime.Serialization;

namespace Travix.Services.Contracts
{
	[DataContract]
	public class Identifier : IDataObject
	{
		public Identifier()
		{

		}

		public Identifier(int id)
		{
			Id = id;
		}

		[DataMember(Name = Naming.Id)]
		public int Id { get; set; }
	}
}
