using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Travix.Services.Contracts.Comments
{
	[DataContract]
	public class Comment : MessageBase
	{
		public Comment()
		{
		}

		public Comment(int id)
			: base(id)
		{
		}

		public Comment(int id, int createdBy, DateTime createdAt)
			: base(id, createdBy, createdAt)
		{
		}

		public Comment(int id, string body, int createdBy, DateTime createdAt)
			: this(id, createdBy, createdAt)
		{
			Body = body;
		}

		[DataMember(Name = Naming.Comments.PostId)]
		[Required]
		[Range(1, Int32.MaxValue)]
		public int PostId { get; set; }

		[DataMember(Name = Naming.Comments.CommentBody)]
		[Required]
		public string Body { get; set; }
	}
}
