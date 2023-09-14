using TodoList.Domain.Enums;

namespace TodoList.Application.DTOs.Task;

public class GetAllTasksRequestJson
{
    public string Title { get; set; }
    public TaskEnum? Type { get; set; }
}
