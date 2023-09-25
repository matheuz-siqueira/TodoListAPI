using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data;

namespace TodoList.Infra.Repositories.Task;

public class TaskRepository : ITaskRepository
{
    private readonly Context _context;
    public TaskRepository(Context context)
    {
        _context = context;
    }
    public async Task<IList<Domain.Models.Task>> GetAllAsync(int userId)
    {
        return await _context.Tasks.AsNoTracking()
            .Where(t => t.UserId == userId && t.Status == false).ToListAsync();
    }

    public async Task<Domain.Models.Task> GetByIdAsync(int userId, int taskId)
    {
        return await _context.Tasks.AsNoTracking()
            .Include(t => t.SubTasks)
            .Where(t => t.UserId == userId)
            .FirstOrDefaultAsync(t => t.Id == taskId);
    }

    public async Task<Domain.Models.Task> GetByIdTracking(int userId, int taskId)
    {
        return await _context.Tasks.Where(t => t.UserId == userId)
            .Include(t => t.SubTasks)
            .FirstOrDefaultAsync(t => t.Id == taskId);
    }

    public async Task<Domain.Models.Task> RegisterAsync(Domain.Models.Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async System.Threading.Tasks.Task RemoveAsync(TodoList.Domain.Models.Task task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }
}
