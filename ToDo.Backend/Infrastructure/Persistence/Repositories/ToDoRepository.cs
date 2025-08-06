
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDo.Core.Interfaces;
using ToDo.Core.Models;

namespace Infrastructure.Persistence.Repositories
{
    public class ToDoRepository : IToDoRepository
    {

        private readonly IDbContextFactory<ToDoDBContext> _dbContextFactory;

        public ToDoRepository(IDbContextFactory<ToDoDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public ToDoItem Add(ToDoItem todo)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Add(todo);
            context.SaveChanges();
            return todo;
        }

        public async Task<ToDoItem> AddAsync(ToDoItem todo)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.Add(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        public bool Delete(Guid id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var item = context.ToDoItems.Find(id);
            if(item == null)
            {
                return false;
            }
            context.Remove(item);
            context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var item = await context.ToDoItems.FindAsync(id);
            if (item == null)
            {
                return false;
            }
            context.Remove(item);
            await context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<ToDoItem> GetAllToDos()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.ToDoItems.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllToDosAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.ToDoItems.AsNoTracking().ToListAsync();
        }

        public ToDoItem? GetToDoById(Guid id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.ToDoItems.AsNoTracking().FirstOrDefault(todo => todo.id == id);
        }

        public async Task<ToDoItem?> GetToDoByIdAsync(Guid id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.ToDoItems.AsNoTracking().FirstOrDefaultAsync(todo => todo.id == id);
        }

        public bool Update(ToDoItem todo)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var up = context.ToDoItems.Update(todo);
            if(up == null)
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }

        public Task<bool> UpdateAsync(ToDoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}
