using Microsoft.EntityFrameworkCore;
using ToDoRestApi.Model;

namespace ToDoRestApi.DataContext
{
	public class ToDoDbContext : DbContext
	{
		public DbSet<ToDoItem> ToDos { get; set; }

		public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ToDoItem>().ToTable("ToDos");
		}
	}
}
