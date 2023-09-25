namespace TodoList.Domain.Interfaces;

public interface IDashboardRepository
{
    Task<int> AllCompletedAsync(int userId);
}
