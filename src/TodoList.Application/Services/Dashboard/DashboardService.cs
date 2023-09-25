using TodoList.Application.DTOs.Dashboard;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _repository;
    private readonly IUserLogged _logged;
    public DashboardService(IDashboardRepository repository, IUserLogged logged)
    {
        _repository = repository;
        _logged = logged;
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
}
