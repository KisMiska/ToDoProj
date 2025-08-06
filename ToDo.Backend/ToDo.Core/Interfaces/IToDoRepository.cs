
using ToDo.Core.Models;

namespace ToDo.Core.Interfaces
{
    public interface IToDoRepository
    {
        public ToDoItem? GetToDoById(Guid id);

        public IEnumerable<ToDoItem> GetAllToDos();

        public ToDoItem Add(ToDoItem todo);

        public bool Update(ToDoItem todo);

        public bool Delete(Guid id);

        public Task<ToDoItem?> GetToDoByIdAsync(Guid id);

        public Task<IEnumerable<ToDoItem>> GetAllToDosAsync();

        public Task<ToDoItem> AddAsync(ToDoItem todo);

        public Task<bool> UpdateAsync(ToDoItem todo);

        public Task<bool> DeleteAsync(Guid id);

    }
}
