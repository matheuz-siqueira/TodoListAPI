using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Models;

namespace TodoList.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}