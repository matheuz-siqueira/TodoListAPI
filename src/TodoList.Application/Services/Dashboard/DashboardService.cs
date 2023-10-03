using AutoMapper;
using TodoList.Application.DTOs.Dashboard;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _repository;
    private readonly ITaskRepository _taskRepo;
    private readonly IUserLogged _logged;
    private readonly IMapper _mapper;
    public DashboardService(IDashboardRepository repository, IUserLogged logged,
        IMapper mapper, ITaskRepository taskRepo)
    {
        _repository = repository;
        _logged = logged;
        _mapper = mapper;
        _taskRepo = taskRepo;
    }
    public async Task<AllCompletedResponseJson> AllCompletedAsync()
    {
        var userId = _logged.GetCurrentUserId();
        var allCompleted = await _repository.AllCompletedAsync(userId);
        return new AllCompletedResponseJson
        {
            AllCompleted = allCompleted
        };
    }

    public async Task<AllPendingResponseJson> AllPendingAsync()
    {
        var userId = _logged.GetCurrentUserId();
        var allPending = await _repository.AllPedingAsync(userId);
        return new AllPendingResponseJson
        {
            AllPending = allPending
        };
    }
    public async System.Threading.Tasks.Task RemoveAllAsync()
    {
        var userId = _logged.GetCurrentUserId();
        var completed = await _repository.RecordAsync(userId);
        if (completed.Any())
        {
            await _repository.RemoveAllAsync(completed);
        }
    }

    public async Task<IList<RecordResponseJson>> RercordAsync()
    {
        var userId = _logged.GetCurrentUserId();
        var record = await _repository.RecordAsync(userId);
        var response = _mapper.Map<List<RecordResponseJson>>(record);
        return response;
    }


}
