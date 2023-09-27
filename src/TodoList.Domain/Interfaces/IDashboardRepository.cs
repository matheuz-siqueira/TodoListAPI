using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces;

public interface IDashboardRepository
{
    Task<int> AllCompletedAsync(int userId);
    Task<int> AllPedingAsync(int userId);
    Task<List<Record>> RecordAsync(int userId);
    System.Threading.Tasks.Task RemoveAllAsync(List<Domain.Models.Record> completed);
}
