
using Application.DTOs;
using Application.Services.Interfaces;
using Application.Validation;
using AutoMapper;
using FluentValidation;
using ToDo.Core.Interfaces;
using ToDo.Core.Models;

namespace Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        private readonly IMapper _mapper;

        private readonly IValidator<CreateToDoItemDTO> _createValidator;

        private readonly IValidator<UpdateToDoTitemDTO> _updateValidator;

        public ToDoService(IToDoRepository repo, IMapper mapper, IValidator<CreateToDoItemDTO> createValidator, IValidator<UpdateToDoTitemDTO> updateValidator)
        {
            this._repository = repo;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._updateValidator = updateValidator;
        }

        public GetToDoItemDTO Add(CreateToDoItemDTO todo)
        {
            _createValidator.ValidateAndThrow(todo);
            var todoItem = _mapper.Map<ToDoItem>(todo);
            todoItem.id = Guid.NewGuid();
            var createdTodo = _repository.Add(todoItem);
            return _mapper.Map<GetToDoItemDTO>(createdTodo);
        }

        public async Task<GetToDoItemDTO> AddAsync(CreateToDoItemDTO todo)
        {
            await _createValidator.ValidateAndThrowAsync(todo);
            var todoItem = _mapper.Map<ToDoItem>(todo);
            todoItem.id = Guid.NewGuid();
            var createdTodo = await _repository.AddAsync(todoItem);
            return _mapper.Map<GetToDoItemDTO>(createdTodo);
        }

        public DeleteResponseDTO Delete(Guid id)
        {
            return new DeleteResponseDTO(_repository.Delete(id));
        }

        public async Task<DeleteResponseDTO> DeleteAsync(Guid id)
        {
            // return await _repository.DeleteAsync(id);
            return new DeleteResponseDTO(await _repository.DeleteAsync(id));
        }

        public IEnumerable<GetToDoItemDTO> GetAllToDos()
        {
            var todos = _repository.GetAllToDos();
            return _mapper.Map<IEnumerable<GetToDoItemDTO>>(todos);
        }

        public async Task<IEnumerable<GetToDoItemDTO>> GetAllToDosAsync()
        {
            var todos = await _repository.GetAllToDosAsync();
            return _mapper.Map<IEnumerable<GetToDoItemDTO>>(todos);
        }

        public GetToDoItemDTO? GetToDoById(Guid id)
        {
            var todo = _repository.GetToDoById(id);
            if (todo == null)
            {
                return null;
            }
            return _mapper.Map<GetToDoItemDTO>(todo);
            
        }

        public async Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id)
        {
            var todo = await _repository.GetToDoByIdAsync(id);
            if (todo == null)
            {
                return null;
            }
            return _mapper.Map<GetToDoItemDTO>(todo);
        }

        public UpdateResponseDTO Update(Guid id, UpdateToDoTitemDTO todo)
        {
            _updateValidator.ValidateAndThrow(todo);
            var newTodo = _mapper.Map<ToDoItem>(todo);
            newTodo.id = id;
            return new UpdateResponseDTO(_repository.Update(newTodo));
        }

        public async Task<UpdateResponseDTO> UpdateAsync(Guid id, UpdateToDoTitemDTO todo)
        {
            await _updateValidator.ValidateAndThrowAsync(todo);
            var newTodo = _mapper.Map<ToDoItem>(todo);
            newTodo.id = id;
            return new UpdateResponseDTO(await _repository.UpdateAsync(newTodo));
        }
    }
}
