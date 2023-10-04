using Microsoft.AspNetCore.Mvc;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.Dashboard;
using TodoList.Application.Exceptions.TodoListExceptions;


namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/dashboard")]
public class DashboardController : TodoListController
{
    private readonly IDashboardService _service;
    private readonly ITaskService _taskService;
    private readonly IRecordService _recordService;
    public DashboardController(
        IDashboardService service, ITaskService taskService, IRecordService recordService)
    {
        _service = service;
        _taskService = taskService;
        _recordService = recordService;
    }

    ///<summary>
    ///Obter total de tarefas concluídas
    ///</summary> 
    ///<response code="200">Sucesso</response> 
    ///<response code="204">Sucesso</response>
    ///<response code="400">Erro na requisição</response> 
    ///<response code="401">Não autenticado</response>
    [HttpGet("all-completed")]
    public async Task<ActionResult<AllCompletedResponseJson>> AllCompletedAsync()
    {
        var response = await _service.AllCompletedAsync();
        return Ok(response);
    }

    ///<summary>
    ///Obter total de tarefas pendentes
    ///</summary> 
    ///<response code="200">Sucesso</response> 
    ///<response code="204">Sucesso</response>
    ///<response code="400">Erro na requisição</response> 
    ///<response code="401">Não autenticado</response>
    [HttpGet("all-pending")]
    public async Task<ActionResult<AllPendingResponseJson>> AllPendingAsync()
    {
        var response = await _service.AllPendingAsync();
        return Ok(response);
    }

    ///<summary> 
    ///Obter todas as tarefas concluídas ordenadas por data de conclusão
    ///</summary>
    ///<returns>Lista de tarefas concluídas</returns>
    ///<response code="200">Sucesso</response> 
    ///<response code="204">Sucesso</response>
    ///<response code="400">Erro na requisição</response> 
    ///<response code="401">Não autenticado</response>  
    [HttpGet("record-completed")]
    public async Task<ActionResult<IList<RecordResponseJson>>> RecordAsync()
    {
        var response = await _service.RercordAsync();
        if (!response.Any())
        {
            return NoContent();
        }
        return Ok(response);
    }

    ///<summary> 
    ///Remover todo o registro de tarefas concluídas
    ///</summary> 
    ///<returns>Nada</returns> 
    ///<response code="200">Sucesso</response>
    ///<response code="204">Sucesso</response> 
    ///<response code="400">Erro na requisição</response>
    [HttpDelete("remove-all")]
    public async Task<ActionResult> RemoveAsync()
    {
        try
        {
            await _service.RemoveAllAsync();
            return NoContent();
        }
        catch
        {
            return BadRequest(new { message = "invalid request" });
        }
    }

    ///<summary> 
    ///Tornar tarefa desfeita
    ///</summary> 
    ///<params name="id">Id da tarefa</params> 
    ///<returns>Nada</returns> 
    ///<response code="200">Sucesso</response>
    ///<response code="204">Sucesso</response>
    ///<response code="400">Erro na requisição</response>
    ///<response code="401">Não autenticado</response>
    ///<response code="404">Não encontrado</response>
    [HttpPut("task-undone/{id}")]
    public async Task<ActionResult> TaskUndone(string id)
    {
        try
        {
            await _taskService.UndoneAsync(id);
            return NoContent();
        }
        catch (TaskNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch
        {
            return BadRequest(new { message = "invalid request" });
        }
    }

    ///<summary>
    ///Remover um registro de tarefas 
    ///</summary> 
    ///<params name="id">Id do registro</params>
    ///<returns>Nada</returns> 
    ///<response code="200">Sucesso</response>
    ///<response code="204">Sucesso</response>
    ///<response code="400">Erro na requisição</response>
    ///<response code="401">Não autenticado</response>
    ///<response code="404">Registro não encontrado</response>
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> RemoveByIdAsync(string id)
    {
        try
        {
            await _recordService.RemoveAsync(id);
            return NoContent();
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch
        {
            return BadRequest(new { message = "invalid request" });
        }
    }
}
