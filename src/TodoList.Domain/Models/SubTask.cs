namespace TodoList.Domain.Models;

public class SubTask : BaseEntity
{
    public string Title { get; set; }
    public bool Status { get; set; } = false;
    //navigation property 
    public Task Task { get; set; }

    //foreign key 
    public int TaskId { get; set; }

}
