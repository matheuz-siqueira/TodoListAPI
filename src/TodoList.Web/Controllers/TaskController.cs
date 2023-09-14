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
    ///<summary> 
    ///Registrar uma tarefa
    ///</summary>
    ///<remarks> 
    ///{"title":"string","description":"string","type":0,"startDate":"2023-09-14T01:33:01.549Z","finishDate":"2023-09-14T01:33:01.549Z","subTasks":[{"title":"string"}]}
    ///</remarks>
    ///<params name="request">Dados da tarefa</params> 
    ///<returns>Tarefa registrada</returns> 
    ///<response code="201">Sucesso</response> 
    ///<response code="400">Erro na requisição</response> 

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

    ///<summary> 
    ///Obter todas as tarefas
    ///</summary>
    ///<remarks> 
    ///{"title":"string","type":0}
    ///</remarks> 
    ///<params name="request">Filtro de pesquisa</params> 
    ///<returns>Lista de tarefas</returns> 
    ///<response code="200">Sucesso</response> 
    ///<response code="204">Sucesso</response> 
    [HttpPost("get-all")]
    public async Task<ActionResult<IList<GetAllTaskResponseJson>>> GetAllAsync(
        GetAllTasksRequestJson request)
    {
        var response = await _service.GetAllAsync(request);
        if (!response.Any())
        {
            return NoContent();
        }
        return Ok(response);
    }
}
