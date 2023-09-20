using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.Note;
using TodoList.Application.Exceptions.ValidatorsExceptions;
using TodoList.Application.Exceptions.TodoListExceptions;

namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/notes")]
public class NoteController : TodoListController
{
    private readonly INoteService _service;
    private readonly IValidator<RegisterNoteRequestJson> _validatorRegisterNote;
    public NoteController(INoteService service,
        IValidator<RegisterNoteRequestJson> validatorRegisterNote)
    {
        _service = service;
        _validatorRegisterNote = validatorRegisterNote;
    }

    ///<summary> 
    ///Registrando uma anotação 
    ///</summary> 
    ///<remarks> 
    ///{"annotation":"string"}
    ///</remarks> 
    ///<params name="request">Texto da anotação</params> 
    ///<returns>Anotação registrada</returns> 
    ///<response code="200">Sucesso</response> 
    ///<response code="400">Erro na requisição</response>
    ///<response code="401">Não autenticado</response>
    [HttpPost("register-note")]
    public async Task<ActionResult<RegisterNoteResponseJson>> RegisterAsync(
        RegisterNoteRequestJson request)
    {
        var result = _validatorRegisterNote.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.ToCustomValidationFailure());
        }
        var response = await _service.RegisterAsync(request);
        return Ok(response);

    }

    ///<summary>
    ///Obter anotação pelo ID 
    ///</summary> 
    ///<params name="id">Id da anotação</params> 
    ///<returns>Anotação</returns> 
    ///<response code="200">Sucesso</response>
    ///<response code="400">Erro na requisição</response> 
    ///<response code="401">Não autenticado</response> 
    ///<response code="404">Anotação não encontrada</response>
    [HttpGet("get-by-id/{id}")]
    public async Task<ActionResult<GetNoteResponseJson>> GetByIdAsync(string id)
    {
        try
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }
        catch (NoteNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (InvalidIDException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}
