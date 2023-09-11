namespace TodoList.Domain.Models;

public class SubTask : BaseEntity
{
    public string Title { get; set; }

    //navigation property 
    public Task Task { get; set; }

    //foreign key 
    public int TaskId { get; set; }

}
