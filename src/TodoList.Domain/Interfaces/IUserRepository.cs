using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces;
public interface IUserRepository
{
    System.Threading.Tasks.Task RegisterAsync(User user);
    Task<User> GetByEmail(string email);
    Task<User> GetProfileAsync(int id);
    System.Threading.Tasks.Task UpdatePasswordAsync(User user);
    Task<User> GetById(int id);
}
