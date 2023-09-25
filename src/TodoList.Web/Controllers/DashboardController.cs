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
}
