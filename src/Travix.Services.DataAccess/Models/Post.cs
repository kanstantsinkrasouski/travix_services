using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travix.Services.DataAccess.Models
{
	[Table(Naming.Tables.Posts)]
	public sealed class Post : IEntity
	{
		public Post()
		{

		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(Naming.Columns.Id)]
		public int Id { get; set; }
		[Column(Naming.Columns.CreatedBy)]
		public int CreatedBy { get; set; }
		[Column(Naming.Columns.CreatedAt)]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime CreatedAt { get; set; }
		[Column(Naming.Columns.Body)]
		public string Body { get; set; }
		public IEnumerable<Comment> Comments { get; set; }
	}
}
