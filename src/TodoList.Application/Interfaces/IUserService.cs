using TodoList.Application.DTOs.User;

namespace TodoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponseJson> RegisterAsync(RegisterUserRequestJson request);
    }
}