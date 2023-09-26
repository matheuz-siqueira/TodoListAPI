using TodoList.Application.DTOs.Task;

namespace TodoList.Application.DTOs.Dashboard;

public class RecordResponseJson
{
    public string Id { get; set; }
    public DateOnly Date { get; set; }
    public List<RegisterTaskResponseJson> Tasks { get; set; }
}
