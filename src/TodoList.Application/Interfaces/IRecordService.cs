namespace TodoList.Application.Interfaces;
public interface IRecordService
{
    Task RegisterAsync(Domain.Models.Task task);
}
