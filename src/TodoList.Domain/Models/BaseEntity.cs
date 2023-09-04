namespace TodoList.Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}