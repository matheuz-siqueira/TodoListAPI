namespace TodoList.Application.DTOs.Task;

public class RegisterTaskResponseJson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime FinishDate { get; set; }
}
