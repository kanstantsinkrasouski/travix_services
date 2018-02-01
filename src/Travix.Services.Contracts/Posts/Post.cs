using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Travix.Services.Contracts.Posts
{
	[DataContract]
	public class Post : MessageBase
	{
		public Post()
		{
		}

		public Post(int id)
			: base(id)
		{
		}

		public Post(int id, int createdBy, DateTime createdAt)
			: base(id, createdBy, createdAt)
		{
		}

		public Post(int id, string body, int createdBy, DateTime createdAt)
			: this(id, createdBy, createdAt)
		{
			Body = body;
		}

		[DataMember(Name = Naming.Posts.PostBody)]
		[Required]
		public string Body { get; set; }
	}
}
