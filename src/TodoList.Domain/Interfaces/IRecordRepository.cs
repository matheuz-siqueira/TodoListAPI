using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces;

public interface IRecordRepository
{
    System.Threading.Tasks.Task RegisterAsync(Record record);
    Task<Record> GetByDateAsync(DateOnly date, int userId);
    Task<Record> GetByIdAsync(int userId, int recordId);
    System.Threading.Tasks.Task UpdateAsync();
    System.Threading.Tasks.Task RemoveAsync(Record record);

}
