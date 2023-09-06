using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TodoList.Application.Interfaces;

namespace TodoList.Application.Services.BaseServices;

public class UserLogged : IUserLogged
{
    private IHttpContextAccessor _httpContextAccessor;

    public UserLogged(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetCurrentUserId()
    {
        var id = int.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
        return id;
    }
}
