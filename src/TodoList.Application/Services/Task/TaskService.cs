using AutoMapper;
using TodoList.Application.DTOs.Task;
using TodoList.Application.Interfaces;
using TodoList.Application.Services.BaseServices;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.Task;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly IUserLogged _logged;
    private readonly IMapper _mapper;
    public TaskService(
        ITaskRepository repository,
        IUserLogged logged,
        IMapper mapper)
    {
        _repository = repository;
        _logged = logged;
        _mapper = mapper;
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
}
