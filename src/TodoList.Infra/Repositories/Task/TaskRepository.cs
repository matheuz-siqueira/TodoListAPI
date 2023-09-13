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
    public async Task<Domain.Models.Task> RegisterAsync(Domain.Models.Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }
}
