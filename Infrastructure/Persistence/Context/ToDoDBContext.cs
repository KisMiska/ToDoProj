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
    }
}
