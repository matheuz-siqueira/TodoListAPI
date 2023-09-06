using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Web.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class TodoListController : ControllerBase
{

}
