using Microsoft.AspNetCore.Mvc;


namespace TodoList.Web.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class TodoListController : ControllerBase
{

}
