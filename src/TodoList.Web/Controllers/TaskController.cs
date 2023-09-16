using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.Task;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Exceptions.ValidatorsExceptions;


namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/tasks")]
public class TaskController : TodoListController
{
    private readonly ITaskService _service;
    private readonly IValidator<RegisterTaskRequestJson> _registerTaskValidator;
    private readonly IValidator<UpdateTaskRequestJson> _updateTaskValidator;

    public TaskController(ITaskService service,
        IValidator<RegisterTaskRequestJson> registerTaskValidator,
        IValidator<UpdateTaskRequestJson> updateTaskValidator)
    {
        _service = service;
        _registerTaskValidator = registerTaskValidator;
        _updateTaskValidator = updateTaskValidator;
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

    ///<summary> 
    ///Obter tarefa por ID
    ///</summary> 
    ///<params name="id">Id da tarefa</params> 
    ///<returns>Tarefa</returns> 
    ///<response code="200">Sucesso</response> 
    ///<response code="404">Não encontrado</response>
    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult<GetTaskResponseJson>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }
        catch (TaskNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    ///<summary> 
    ///Atualizar tarefa
    ///</summary> 
    ///<remarks> 
    ///
    ///</remarks> 
    ///<params name="id">Id da tarefa</params> 
    ///<params name="request">Dados da tarefa</params> 
    ///<returns>Nada</returns>
    ///<response code="200">Sucesso</response>
    ///<response code="204">Sucesso</response>
    ///<response code="400">Erro na requisição</response>
    ///<response code="401">Não autenticado</response>
    ///<response code="404">Não encontrado</response>



    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAsync(UpdateTaskRequestJson request, int id)
    {
        var result = _updateTaskValidator.Validate(request);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.ToCustomValidationFailure());
        }
        try
        {
            await _service.UpdateAsync(request, id);
            return NoContent();
        }
        catch (TaskNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    ///<summary> 
    ///Remover tarefa por ID
    ///</summary> 
    ///<returns>Nada</returns> 
    ///<params name="id">Id da tarefa</params> 
    ///<response code="200">Sucesso</response>
    ///<response code="204">Sucesso</response> 
    ///<response code="401">Nâo autenticado</response>
    ///<response code="404">Não encontrado</response> 

    [HttpDelete("remove/{id:int}")]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        try
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }
        catch (TaskNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}
