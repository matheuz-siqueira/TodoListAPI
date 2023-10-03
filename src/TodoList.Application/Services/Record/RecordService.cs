using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.Record;

public class RecordService : IRecordService
{
    private readonly IRecordRepository _repository;
    private readonly IUserLogged _logged;
    public RecordService(IRecordRepository repository, IUserLogged logged)
    {
        _repository = repository;
        _logged = logged;
    }

    public async System.Threading.Tasks.Task RegisterAsync(Domain.Models.Task task)
    {
        var query = await _repository.GetByDateAsync(task.CompletedAt, task.UserId);
        if (query is null)
        {
            var record = new Domain.Models.Record();
            record.Date = task.CompletedAt;
            record.UserId = task.UserId;
            record.Tasks.Add(task);
            await _repository.RegisterAsync(record);
        }
        else
        {
            query.Tasks.Add(task);
            await _repository.UpdateAsync();
        }
    }

    public async System.Threading.Tasks.Task RemoveDeleted(Domain.Models.Task task)
    {
        var userId = _logged.GetCurrentUserId();
        var record = await _repository.GetByDateAsync(task.CompletedAt, userId);
        if (record.Tasks.Count == 1)
        {
            await _repository.RemoveAsync(record);
        }

    }

    public async System.Threading.Tasks.Task RemoveUndone(
        DateOnly date, Domain.Models.Task task)
    {
        var userId = _logged.GetCurrentUserId();
        var record = await _repository.GetByDateAsync(date, userId);
        if (record.Tasks.Count == 1)
        {
            await _repository.RemoveAsync(record);
        }
        else
        {
            record.Tasks.Remove(task);
            await _repository.UpdateAsync();
        }
    }
}
