using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.User;
using TodoList.Application.Exceptions.ValidatorsExceptions;
using TodoList.Application.Exceptions.TodoListExceptions;

namespace TodoList.Web.Controllers;

public class UserController : TodoListController
{
    private readonly IUserService _services;
    private readonly IValidator<RegisterUserRequestJson> _validatorRegisterUser;

    public UserController(IUserService services,
        IValidator<RegisterUserRequestJson> validatorRegisterUser)
    {
        _services = services;
        _validatorRegisterUser = validatorRegisterUser;
    }

    [HttpPost("create-account")]
    public async Task<ActionResult<LoginResponseJson>> RegisterAsync(RegisterUserRequestJson request)
    {
        var result = _validatorRegisterUser.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.ToCustomValidationFailure());
        }

        try
        {
            var response = await _services.RegisterAsync(request);
            return StatusCode(201, response);
        }
        catch (DifferentPasswordsException e)
        {
            return BadRequest(new { message = e.Message });
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}
