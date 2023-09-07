using TodoList.Application.DTOs.User;
using TodoList.Domain.Models;

namespace TodoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponseJson> RegisterAsync(RegisterUserRequestJson request);
        Task<GetProfileResponseJson> GetProfileAsync();

        Task UpdatePasswordAsync(UpdatePasswordRequestJson request);
    }
}