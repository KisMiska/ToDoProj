
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

        public bool Delete(Guid id)
        {
           return _repository.Delete(id);
        }

        public IEnumerable<GetToDoItemDTO> GetAllToDos()
        {
            var todos = _repository.GetAllToDos();
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

        public bool Update(Guid id, UpdateToDoTitemDTO todo)
        {
            _updateValidator.ValidateAndThrow(todo);
            var newTodo = _mapper.Map<ToDoItem>(todo);
            newTodo.id = id;
            return _repository.Update(newTodo);
        }
    }
}
