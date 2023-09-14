using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.Task;
using TodoList.Application.Exceptions.ValidatorsExceptions;

namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/tasks")]
public class TaskController : TodoListController
{
    private readonly ITaskService _service;
    private readonly IValidator<RegisterTaskRequestJson> _registerTaskValidator;

    public TaskController(ITaskService service,
        IValidator<RegisterTaskRequestJson> registerTaskValidator)
    {
        _service = service;
        _registerTaskValidator = registerTaskValidator;
    }

    [Authorize]
    [HttpPost("register-task")]
    public async Task<ActionResult<RegisterTaskResponseJson>> RegisterAsync(
        RegisterTaskRequestJson request)
    {
        var result = _registerTaskValidator.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.ToCustomValidationFailure());
        }

        var response = await _service.RegisterAsync(request);
        return StatusCode(201, response);
    }
}
