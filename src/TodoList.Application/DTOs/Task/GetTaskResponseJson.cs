namespace TodoList.Application.DTOs.Task;

public class GetTaskResponseJson
{
    public string Id { get; set; }
    public bool Status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime FinishDate { get; set; }
    public IList<GetSubTasksResponseJson> SubTasks { get; set; }
}
