using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly IToDoService _toDoService;

        public ToDoController(ILogger<ToDoController> logger, IToDoService toDoService)
        {
            _logger = logger;
            _toDoService = toDoService;
        }

        [HttpGet("todos")]
        public IActionResult GetAllToDoItems()
        {
            _logger.LogInformation("Received request to get all todo items.");
            var items = _toDoService.GetAllToDos();
            return Ok(items);
        }

        [HttpGet("todos/{id}")]
        public IActionResult GetById(Guid id)
        {
            _logger.LogInformation("Received request to get todo item byid", id);
            var item = _toDoService.GetToDoById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpDelete("todos/{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Received request to delete todo item", id);

            var result = _toDoService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("todos")]
        public IActionResult Add([FromBody] CreateToDoItemDTO createDto)
        {
            _logger.LogInformation("Received request to add a new item");

            try
            {
                var result = _toDoService.Add(createDto);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                _logger.LogError("Validation error in add");
                return BadRequest(e.Errors);
            }
            catch (Exception e)
            {
                _logger.LogError("idk error in add");
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPatch("todos/{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateToDoTitemDTO updateDto)
        {
            _logger.LogInformation("Received request to update", id);

            try
            {
                var result = _toDoService.Update(id, updateDto);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, "Validation error update.");
                return BadRequest(e.Errors);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unexpected error occurred during update.");
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("todos/v2")]
        public async Task<IActionResult> GetAllToDoItemsAsync()
        {
            _logger.LogInformation("Received request to get all todo items.");
            var items = await _toDoService.GetAllToDosAsync();
            return Ok(items);
        }

        [HttpGet("todos/v2/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Received request to get todo item by ID asynchronously: {Id}", id);
            var item = await _toDoService.GetToDoByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpDelete("todos/v2/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            _logger.LogInformation("Received request to delete todo item asynchronously: {Id}", id);
            var result = await _toDoService.DeleteAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost("todos/v2")]
        public async Task<IActionResult> AddAsync([FromBody] CreateToDoItemDTO createDto)
        {
            _logger.LogInformation("Received request to add a new todo item asynchronously.");

            try
            {
                var result = await _toDoService.AddAsync(createDto);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, "Validation error occurred while adding a todo item.");
                return BadRequest(e.Errors);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unexpected error occurred while adding a todo item.");
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPatch("/todos/v2/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateToDoTitemDTO updateDto)
        {
            _logger.LogInformation("Received request to update todo item asynchronously: {Id}", id);

            try
            {
                var result = await _toDoService.UpdateAsync(id, updateDto);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, "Validation error occurred during update.");
                return BadRequest(e.Errors);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unexpected error occurred during update.");
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }


    }
}
