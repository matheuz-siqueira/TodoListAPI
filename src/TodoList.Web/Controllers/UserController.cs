using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.User;
using TodoList.Application.Exceptions.ValidatorsExceptions;
using TodoList.Application.Exceptions.TodoListExceptions;

namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/users")]
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

    [AllowAnonymous]
    [HttpPost("create-account")]
    public async Task<ActionResult<AuthenticationResponseJson>> RegisterAsync(RegisterUserRequestJson request)
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
        catch (ExistingUserException e)
        {
            return BadRequest(new { message = e.Message });
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpGet("get-profile")]
    public async Task<ActionResult<GetProfileResponseJson>> GetProfileAsync()
    {
        try
        {
            var response = await _services.GetProfileAsync();
            return Ok(response);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (BadHttpRequestException)
        {
            return BadRequest(new { message = "unauthorized access" });
        }
    }
}
