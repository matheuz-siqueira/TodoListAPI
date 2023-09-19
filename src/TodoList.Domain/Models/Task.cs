using TodoList.Domain.Enums;

namespace TodoList.Domain.Models;

public class Task : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskEnum Type { get; set; }
    public DateTime FinishDate { get; set; }
    public bool Status { get; set; }

    //navigation property 
    public User User { get; set; }
    public Note Note { get; set; }
    public IList<SubTask> SubTasks { get; set; }

    //foreign key 
    public int UserId { get; set; }


}
