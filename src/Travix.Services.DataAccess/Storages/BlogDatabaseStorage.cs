using Microsoft.EntityFrameworkCore;
using Travix.Services.DataAccess.Models;

namespace Travix.Services.DataAccess.Storages
{
	internal class BlogDatabaseStorage : DataBaseStorage, IBlogDatabaseStorage
	{
		public BlogDatabaseStorage()
			: base(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Travix.db"))//TODO: inject db configuration
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Post>(postBuilder =>
			{
				postBuilder.Property(post => post.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
			});
			modelBuilder.Entity<Comment>(commentBuilder =>
			{
				commentBuilder.Property(comment => comment.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
			});
			modelBuilder.Entity<Comment>().
				HasOne<Post>().
				WithMany(post => post.Comments).
				OnDelete(DeleteBehavior.Cascade);
		}

		protected DbSet<Post> Posts { get; set; }
		protected DbSet<Comment> Comments { get; set; }
	}
}
