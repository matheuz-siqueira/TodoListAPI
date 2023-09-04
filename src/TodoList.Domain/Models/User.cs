namespace TodoList.Domain.Models
{
    public sealed class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}