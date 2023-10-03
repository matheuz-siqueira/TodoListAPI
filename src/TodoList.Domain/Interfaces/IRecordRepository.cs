using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces;

public interface IRecordRepository
{
    System.Threading.Tasks.Task RegisterAsync(Record record);
    Task<Record> GetByDateAsync(DateOnly date, int userId);
    System.Threading.Tasks.Task UpdateAsync();

    System.Threading.Tasks.Task RemoveAsync(Record record);

}
