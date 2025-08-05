using Microsoft.EntityFrameworkCore;
using ToDo.Core.Models;

namespace Infrastructure.Persistence.Context
{
    public class ToDoDBContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems;
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) :  base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoItem>().HasKey(t => t.id);
            modelBuilder.Entity<ToDoItem>().Property(t => t.title).IsRequired().HasMaxLength(100);
        }
    }
}
