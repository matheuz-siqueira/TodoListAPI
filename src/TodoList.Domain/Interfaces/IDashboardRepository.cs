namespace TodoList.Domain.Interfaces;

public interface IDashboardRepository
{
    Task<int> AllCompletedAsync(int userId);
    Task<int> AllPedingAsync(int userId);
}
