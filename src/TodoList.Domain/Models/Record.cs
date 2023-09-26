namespace TodoList.Domain.Models;

public class Record : BaseEntity
{
    public DateOnly Date { get; set; }

    //navigation property 
    public List<Task> Tasks { get; set; } = new List<Task>();
    public User User { get; set; }

    //foreign key 
    public int UserId { get; set; }

}
