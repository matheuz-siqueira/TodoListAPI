namespace TodoList.Domain.Models;

public class Note : BaseEntity
{
    public string Annotation { get; set; }

    //navigation property 
    public User User { get; set; }

    //foreign key 
    public int UserId { get; set; }

}
