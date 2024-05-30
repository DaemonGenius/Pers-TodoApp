using Microsoft.EntityFrameworkCore;
using TaskService.Domain.Entities;

namespace TaskService.Infrastructure.Database.TodoTask.Model;

public static class TodoTaskModel
{
    public static void BuildTodoTaskModel(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.TodoTask>().Property(x => x.Identity)
            .HasConversion(v => v.Reference, v => new TodoTaskIdentity(v));
        modelBuilder.Entity<Domain.Entities.TodoTask>().HasKey(x => x.Identity);
    }
}