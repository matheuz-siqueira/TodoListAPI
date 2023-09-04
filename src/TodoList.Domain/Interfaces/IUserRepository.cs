using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
    }
}