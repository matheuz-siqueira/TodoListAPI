using AutoMapper;
using TodoList.Application.DTOs.Task;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Extensions;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.Task;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly IUserLogged _logged;
    private readonly IMapper _mapper;
    private readonly IHashidsService _hashids;
    private readonly IRecordService _recordService;
    public TaskService(
        ITaskRepository repository,
        IUserLogged logged,
        IMapper mapper,
        IHashidsService hashids,
        IRecordService recordService)
    {
        _repository = repository;
        _logged = logged;
        _mapper = mapper;
        _hashids = hashids;
        _recordService = recordService;
    }

    public async Task<IList<GetAllTaskResponseJson>> GetAllAsync(GetAllTasksRequestJson request)
    {
        var userId = _logged.GetCurrentUserId();
        var tasks = await _repository.GetAllAsync(userId);
        tasks = Filter(request, tasks);
        var response = _mapper.Map<IList<GetAllTaskResponseJson>>(tasks);
        return response;

    }

    public async Task<RegisterTaskResponseJson> RegisterAsync(RegisterTaskRequestJson request)
    {
        var task = _mapper.Map<TodoList.Domain.Models.Task>(request);
        var userId = _logged.GetCurrentUserId();
        task.UserId = userId;
        task.Status = false;
        await _repository.RegisterAsync(task);
        var response = _mapper.Map<RegisterTaskResponseJson>(task);
        return response;
    }
    public async Task<GetTaskResponseJson> GetByIdAsync(string taskId)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(taskId);
        var id = _hashids.Decode(taskId);
        var task = await _repository.GetByIdAsync(userId, id);
        if (task is null)
        {
            throw new TaskNotFoundException("task not found");
        }
        var response = _mapper.Map<GetTaskResponseJson>(task);
        return response;
    }

    public async System.Threading.Tasks.Task RemoveAsync(string taskId)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(taskId);
        var id = _hashids.Decode(taskId);
        var task = await _repository.GetByIdTracking(userId, id);
        if (task is null)
        {
            throw new TaskNotFoundException("task not found");
        }

        if (task.Status == true)
        {
            await _recordService.RemoveDeleted(task);
        }

        await _repository.RemoveAsync(task);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateTaskRequestJson request,
        string taskId)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(taskId);
        var id = _hashids.Decode(taskId);
        var task = await _repository.GetByIdTracking(userId, id);
        if (task is null)
        {
            throw new TaskNotFoundException("task not found");
        }
        if (!task.Status == true)
        {
            if (request.Status == true)
            {
                task.CompletedAt = DateOnly.FromDateTime(DateTime.Now);
                _mapper.Map(request, task);
                await _repository.UpdateAsync();
                await _recordService.RegisterAsync(task);
            }
            _mapper.Map(request, task);
            await _repository.UpdateAsync();
        }
    }

    public async System.Threading.Tasks.Task UndoneAsync(string taskId)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(taskId);
        var id = _hashids.Decode(taskId);
        var task = await _repository.GetByIdTracking(userId, id);
        if (task is null)
        {
            throw new TaskNotFoundException("task not found");
        }
        var date = task.CompletedAt;
        task.Status = false;
        await _repository.UpdateAsync();
        await _recordService.RemoveUndone(date, task);
    }
    private static IList<TodoList.Domain.Models.Task> Filter(
       GetAllTasksRequestJson request, IList<TodoList.Domain.Models.Task> tasks)
    {
        var filters = tasks;
        if (request.Type.HasValue)
        {
            filters = tasks.Where(t => t.Type == request.Type.Value).ToList();
        }
        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            filters = tasks.Where(t => t.Title.CompareNoCase(request.Title)).ToList();
        }
        return filters.OrderBy(t => t.Title).ToList();
    }
}
