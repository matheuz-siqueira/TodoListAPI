namespace TodoList.Domain.Interfaces;
public interface ITaskRepository
{
    Task<TodoList.Domain.Models.Task> RegisterAsync(TodoList.Domain.Models.Task task);
}
