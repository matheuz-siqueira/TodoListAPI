using TodoList.Application.DTOs.Task;

namespace TodoList.Application.Interfaces;
public interface ITaskService
{
    Task<RegisterTaskResponseJson> RegisterAsync(RegisterTaskRequestJson request);
    Task<IList<GetAllTaskResponseJson>> GetAllAsync(GetAllTasksRequestJson request);
    Task<GetTaskResponseJson> GetByIdAsync(string taskId);
    Task RemoveAsync(string taskId);
    Task UpdateAsync(UpdateTaskRequestJson request, string taskId);
    Task UndoneAsync(string taskId);
}
