using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.Record;

public class RecordService : IRecordService
{
    private readonly IRecordRepository _repository;
    public RecordService(IRecordRepository repository, IUserLogged logged)
    {
        _repository = repository;
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
}
