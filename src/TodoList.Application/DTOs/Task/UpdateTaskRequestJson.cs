namespace TodoList.Application.DTOs.Task;

public class UpdateTaskRequestJson : RegisterTaskRequestJson
{
    public bool Status { get; set; }
}
