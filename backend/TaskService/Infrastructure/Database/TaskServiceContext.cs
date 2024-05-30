using Microsoft.EntityFrameworkCore;
using TaskService.Domain;
using TaskService.Infrastructure.Database.Task.Model;

namespace TaskService.Infrastructure.Database;

public class TaskServiceContext: DbContext
{
    public TaskServiceContext(DbContextOptions<TaskServiceContext> options) : base(options)
    {
    }

    public DbSet<TaskState> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.BuildTaskModel();
    }
}