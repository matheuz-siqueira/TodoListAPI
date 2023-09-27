using Microsoft.AspNetCore.Mvc;

using TodoList.Application.Interfaces;
using TodoList.Application.DTOs.Dashboard;

namespace TodoList.Web.Controllers;

[Route("api/v{version:apiVersion}/dashboard")]
public class DashboardController : TodoListController
{
    private readonly IDashboardService _service;
    public DashboardController(IDashboardService service)
    {
        _service = service;
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
}
