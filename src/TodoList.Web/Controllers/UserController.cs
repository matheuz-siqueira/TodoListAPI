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
    private readonly IValidator<UpdatePasswordRequestJson> _validatorUpdatePassword;

    public UserController(IUserService services,
        IValidator<RegisterUserRequestJson> validatorRegisterUser,
        IValidator<UpdatePasswordRequestJson> validatorUpdatePassword)
    {
        _services = services;
        _validatorRegisterUser = validatorRegisterUser;
        _validatorUpdatePassword = validatorUpdatePassword;
    }

    ///<summary> 
    ///Registrar conta no app
    ///</summary> 
    ///<remarks> 
    ///{"name":"string","email":"string","password":"string","confirmPassword":"string"}
    ///</remarks> 
    ///<params name="request">Dados do usuário</params> 
    ///<returns>Token de acesso</returns>
    ///<response code="201">Sucesso</response>
    ///<response code="400">Erro na requisição</response>

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

    ///<summary> 
    ///Obter perfil do usuário logado
    ///</summary>
    ///<returns>Dados da conta</returns> 
    ///<response code="200">Sucesso</response>
    ///<response code="401">Não autenticado</response>
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
    }

    ///<summary> 
    ///Atualizar senha da conta
    ///</summary>
    ///<remarks> 
    ///{"currentPassword":"string","newPassword":"string"}
    ///</remarks> 
    ///<params name="request">Dados para alterar senha</params> 
    ///<returns>Nada</returns> 
    ///<response code="200">Sucesso</response>
    ///<response code="204">Sucesso</response> 
    ///<response code="400">Erro na requisição</response>
    ///<response code="401">Não autenticado</response> 
    [Authorize]
    [HttpPut("update-password")]
    public async Task<ActionResult> UpdatePasswordAsync(UpdatePasswordRequestJson request)
    {
        var result = _validatorUpdatePassword.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.ToCustomValidationFailure());
        }
        try
        {
            await _services.UpdatePasswordAsync(request);
            return NoContent();

        }
        catch (IncorretPasswordException e)
        {
            return BadRequest(new { message = e.Message });
        }

    }
}
