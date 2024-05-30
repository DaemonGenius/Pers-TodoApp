using Microsoft.EntityFrameworkCore;
using TaskService.Infrastructure.Database.TodoTask.Model;

namespace TaskService.Infrastructure.Database;

public class TodoTaskServiceContext: DbContext
{
    public TodoTaskServiceContext(DbContextOptions<TodoTaskServiceContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.TodoTask> TodoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.BuildTodoTaskModel();
    }
}