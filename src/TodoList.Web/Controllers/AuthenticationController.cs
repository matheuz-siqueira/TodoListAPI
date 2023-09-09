using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;



using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.User;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Exceptions.ValidatorsExceptions;

namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/authentication")]
public class AuthenticationController : TodoListController
{
    private readonly IAuthenticationService _service;
    private readonly IValidator<AuthenticationRequestJson> _validatorAuth;

    public AuthenticationController(IAuthenticationService service,
        IValidator<AuthenticationRequestJson> validatorAuth)
    {
        _service = service;
        _validatorAuth = validatorAuth;
    }

    ///<summary> 
    ///Logar no app
    ///</summary> 
    ///<remarks> 
    ///{"email":"string","password":"string"}
    ///</remarks>
    ///<params name="request">Credenciais para login</params> 
    ///<returns>Token de acesso</returns> 
    ///<response code="200">Sucesso</response> 
    ///<response code="400">Erro na requisição</response> 
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponseJson>> Login(
        AuthenticationRequestJson request)
    {
        var result = _validatorAuth.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.ToCustomValidationFailure());
        }

        try
        {
            var response = await _service.Login(request);
            return Ok(response);
        }
        catch (IncorretCredentialsException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}
