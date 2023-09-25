using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data;

namespace TodoList.Infra.Repositories.Dashboard;

public class DashboardRepository : IDashboardRepository
{
    private readonly Context _context;
    public DashboardRepository(Context context)
    {
        _context = context;
    }
    public async Task<int> AllCompletedAsync(int userId)
    {
        return await _context.Tasks.AsNoTracking()
            .Where(task => task.UserId == userId)
            .CountAsync(task => task.Status == true);
    }
    public async Task<int> AllPedingAsync(int userId)
    {
        return await _context.Tasks.AsNoTracking()
            .Where(task => task.UserId == userId)
            .CountAsync(task => task.Status == false);
    }
}
