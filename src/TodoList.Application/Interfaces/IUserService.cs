using TodoList.Application.DTOs.User;

namespace TodoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponseJson> RegisterAsync(RegisterUserRequestJson request);
        Task<GetProfileResponseJson> GetProfileAsync();
    }
}