
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
    }
}
