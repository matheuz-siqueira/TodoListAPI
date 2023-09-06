using TodoList.Application.DTOs.User;

namespace TodoList.Application.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponseJson> Login(AuthenticationRequestJson request);
}
