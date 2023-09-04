using Microsoft.AspNetCore.Mvc;

namespace TodoList.Web.Controllers;

[ApiController]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class TodoListController : ControllerBase
{

}
