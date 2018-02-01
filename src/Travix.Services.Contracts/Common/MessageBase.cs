using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Travix.Services.Contracts
{
	[DataContract]
	public class MessageBase : Identifier
	{
		public MessageBase()
		{
		}

		public MessageBase(int id)
			: base(id)
		{
		}

		public MessageBase(int id, int createdBy, DateTime createdAt)
			: this(id)
		{
			CreatedBy = createdBy;
			CreatedAt = createdAt;
		}

		[DataMember(Name = Naming.CreatedBy)]
		[Required]
		public int CreatedBy { get; set; }
		[DataMember(Name = Naming.CreatedAt, EmitDefaultValue = false)]
		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime? CreatedAt { get; set; }
	}
}
