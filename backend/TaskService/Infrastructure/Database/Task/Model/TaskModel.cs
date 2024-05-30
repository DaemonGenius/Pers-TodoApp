using Microsoft.EntityFrameworkCore;
using TaskService.Domain;

namespace TaskService.Infrastructure.Database.Task.Model;

public static class TaskModel
{
    public static void BuildTaskModel(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskState>().Property(x => x.Identity)
            .HasConversion(v => v.Reference, v => new TaskIdentity(v));
        modelBuilder.Entity<TaskState>().HasKey(x => x.Identity);
        
        // modelBuilder.Entity<TaskState>()
        //     .Property(b => b.FeatureIds)
        //     .HasColumnType("jsonb");
    }
}