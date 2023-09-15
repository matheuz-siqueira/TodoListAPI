namespace TodoList.Domain.Interfaces;
public interface ITaskRepository
{
    Task<TodoList.Domain.Models.Task> RegisterAsync(TodoList.Domain.Models.Task task);
    Task<IList<TodoList.Domain.Models.Task>> GetAllAsync(int userId);
    Task<TodoList.Domain.Models.Task> GetByIdAsync(int userId, int taskId);
}
