namespace TodoList.Domain.Interfaces;
public interface ITaskRepository
{
    Task<TodoList.Domain.Models.Task> RegisterAsync(TodoList.Domain.Models.Task task);
    Task<IList<TodoList.Domain.Models.Task>> GetAllAsync(int userId);
    Task<TodoList.Domain.Models.Task> GetByIdAsync(int userId, int taskId);
    Task<TodoList.Domain.Models.Task> GetByIdTracking(int userId, int taskId);
    Task RemoveAsync(TodoList.Domain.Models.Task task);
    Task UpdateAsync();
    Task<List<TodoList.Domain.Models.Task>> GetAllCompletedAsync(int userId); 
    Task RemoveCompletedAsync (List<TodoList.Domain.Models.Task> tasks);
}
