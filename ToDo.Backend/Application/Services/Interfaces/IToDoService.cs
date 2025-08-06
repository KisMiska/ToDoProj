
using Application.DTOs;
using ToDo.Core.Models;

namespace Application.Services.Interfaces
{
    public interface IToDoService
    {
        public GetToDoItemDTO? GetToDoById(Guid id);

        public IEnumerable<GetToDoItemDTO> GetAllToDos();

        public GetToDoItemDTO Add(CreateToDoItemDTO todo);

        public bool Update(Guid id, UpdateToDoTitemDTO todo);

        public bool Delete(Guid id);

        public Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id);

        public Task<IEnumerable<GetToDoItemDTO>> GetAllToDosAsync();

        public Task<GetToDoItemDTO> AddAsync(CreateToDoItemDTO todo);

        public Task<bool> UpdateAsync(Guid id, UpdateToDoTitemDTO todo);

        public Task<bool> DeleteAsync(Guid id);
    }
}
