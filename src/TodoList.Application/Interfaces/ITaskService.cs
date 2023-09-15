using TodoList.Application.DTOs.Task;

namespace TodoList.Application.Interfaces;
public interface ITaskService
{
    Task<RegisterTaskResponseJson> RegisterAsync(RegisterTaskRequestJson request);
    Task<IList<GetAllTaskResponseJson>> GetAllAsync(GetAllTasksRequestJson request);
    Task<GetTaskResponseJson> GetByIdAsync(int taskId);
    Task RemoveAsync(int taskId);
}
