
using ToDoMauiApp.Model.DTOs;
using Model.DTOs;

namespace ToDoMauiApp.Service.Interfaces
{
    public interface IToDoService
    {
        public Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id);

        public Task<List<GetToDoItemDTO>> GetAllToDosAsync();

        public Task<GetToDoItemDTO> AddAsync(CreateToDoItemDTO todo);

        public Task<UpdateResponseDTO> UpdateAsync(Guid id, UpdateToDoTitemDTO todo);

        public Task<DeleteResponseDTO> DeleteAsync(Guid id);
    }
}
