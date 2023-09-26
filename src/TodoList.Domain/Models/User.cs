namespace TodoList.Domain.Models;
public sealed class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    //navigation property 
    public IList<Task> Tasks { get; set; }
    public IList<Note> Notes { get; set; }
    public IList<Record> Records { get; set; }
}
