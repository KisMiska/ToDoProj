using Application.DTOs;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace FunctionsAPI;

public class ToDoFunction
{
    private readonly ILogger<ToDoFunction> _logger;

    private readonly IToDoService _toDoService;

    public ToDoFunction(ILogger<ToDoFunction> logger, IToDoService toDoService)
    {
        _logger = logger;
        _toDoService = toDoService;
    }

    [Function("GetAllToDoItems")]
    public IActionResult GetAllToDoItems([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to getalltotoditems.");
        var items = _toDoService.GetAllToDos();
        return new OkObjectResult(items);
    }

    [Function("GetById")]
    public IActionResult GetById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todos/{id}") ] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to getbyid.");
        var item = _toDoService.GetToDoById(id);
        return new OkObjectResult(item);
    }

    [Function("Delete")]
    public IActionResult Delete([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to delete.");
        var items = _toDoService.Delete(id);
        return new OkObjectResult(items);
    }

    [Function("Add")]
    public async Task<IActionResult> Add([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to add.");
        try
        {
            String reqBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createDto = JsonConvert.DeserializeObject<CreateToDoItemDTO>(reqBody);
            var items = _toDoService.Add(createDto);
            return new OkObjectResult(items);

        } catch (ValidationException e)
        {
            _logger.LogError("Validation error in add");
            return new BadRequestObjectResult(e.Errors);

        } catch (Exception e)
        {
            _logger.LogError("idk error in add");
            return new ObjectResult(e) {StatusCode = StatusCodes.Status500InternalServerError};
        }
    }

    [Function("Update")]
    public async Task<IActionResult> Update([HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to update.");
        try
        {
            String reqBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDto = JsonConvert.DeserializeObject<UpdateToDoTitemDTO>(reqBody);
            var items = _toDoService.Update(id, updateDto);
            return new OkObjectResult(items);

        }
        catch (ValidationException e)
        {
            _logger.LogError("Valid error in Update");
            return new BadRequestObjectResult(e.Errors);

        }
        catch (Exception e)
        {
            _logger.LogError("Idk error in Update");
            return new ObjectResult(e) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }

    [Function("GetAllToDoItemsAsync")]
    public async Task<IActionResult> GetAllToDoItemsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to getalltotoditemsAsync.");
        var items = await _toDoService.GetAllToDosAsync();
        return new OkObjectResult(items);
    }

    [Function("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to getbyidAsyc.");
        var item = await _toDoService.GetToDoByIdAsync(id);
        return new OkObjectResult(item);
    }

    [Function("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to delteAsync.");
        var items = await _toDoService.DeleteAsync(id);
        return new OkObjectResult(items);
    }

    [Function("AddAsync")]
    public async Task<IActionResult> AddAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v2/todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to AddAsync.");
        try
        {
            String reqBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createDto = JsonConvert.DeserializeObject<CreateToDoItemDTO>(reqBody);
            var items = await _toDoService.AddAsync(createDto);
            return new OkObjectResult(items);

        }
        catch (ValidationException e)
        {
            _logger.LogError("Validation error in addAsync");
            return new BadRequestObjectResult(e.Errors);

        }
        catch (Exception e)
        {
            _logger.LogError("Idk error in addAsync");
            return new ObjectResult(e) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }

    [Function("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to getalltotoditems.");
        try
        {
            String reqBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDto = JsonConvert.DeserializeObject<UpdateToDoTitemDTO>(reqBody);
            var items = await _toDoService.UpdateAsync(id, updateDto);
            return new OkObjectResult(items);

        }
        catch (ValidationException e)
        {
            _logger.LogError("Valid error in UpdateAsync");
            return new BadRequestObjectResult(e.Errors);

        }
        catch (Exception e)
        {
            _logger.LogError("Idk error in Update");
            return new ObjectResult(e) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }




}