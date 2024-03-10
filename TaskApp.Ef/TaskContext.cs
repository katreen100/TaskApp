using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskApp.core.model;

namespace task.Ef
{
    public class TaskContext:IdentityDbContext
    {
        public TaskContext (DbContextOptions<TaskContext> options) : base (options)
        { 
        }
        
        public DbSet<Taskmodel> tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        
    }
}
