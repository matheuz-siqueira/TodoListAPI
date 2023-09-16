using TodoList.Domain.Enums;

namespace TodoList.Application.DTOs.Task;

public class UpdateTaskRequestJson
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public TaskEnum Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public IList<UpdateSubTaskRequestJson> SubTasks { get; set; }
}
