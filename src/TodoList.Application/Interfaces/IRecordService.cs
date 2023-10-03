namespace TodoList.Application.Interfaces;
public interface IRecordService
{
    Task RegisterAsync(Domain.Models.Task task);
    Task RemoveUndone(DateOnly date, Domain.Models.Task task);
    Task RemoveDeleted(Domain.Models.Task task);

}
