using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Models;

namespace TodoList.Infra.Data;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Models.Task> Tasks { get; set; }
    public DbSet<SubTask> SubTasks { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }
}
