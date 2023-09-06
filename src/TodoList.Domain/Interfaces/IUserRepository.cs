using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetProfileAsync(int id);

    }
}