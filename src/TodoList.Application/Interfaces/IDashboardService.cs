using TodoList.Application.DTOs.Dashboard;

namespace TodoList.Application.Interfaces;

public interface IDashboardService
{
    Task<AllCompletedResponseJson> AllCompletedAsync();
    Task<AllPendingResponseJson> AllPendingAsync();
    Task<IList<RecordResponseJson>> RercordAsync();

}
