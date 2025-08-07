
using Application.DTOs;
using ToDo.Core.Models;

namespace Application.Services.Interfaces
{
    public interface IToDoService
    {
        public GetToDoItemDTO? GetToDoById(Guid id);

        public IEnumerable<GetToDoItemDTO> GetAllToDos();

        public GetToDoItemDTO Add(CreateToDoItemDTO todo);

        public UpdateResponseDTO Update(Guid id, UpdateToDoTitemDTO todo);

        public DeleteResponseDTO Delete(Guid id);

        public Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id);

        public Task<IEnumerable<GetToDoItemDTO>> GetAllToDosAsync();

        public Task<GetToDoItemDTO> AddAsync(CreateToDoItemDTO todo);

        public Task<UpdateResponseDTO> UpdateAsync(Guid id, UpdateToDoTitemDTO todo);

        public Task<DeleteResponseDTO> DeleteAsync(Guid id);
    }
}
