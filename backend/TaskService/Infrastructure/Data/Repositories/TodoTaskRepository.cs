using Microsoft.EntityFrameworkCore;
using TaskService.Domain.Entities;
using TaskService.Domain.Interfaces;
using TaskService.Infrastructure.Database;

namespace TaskService.Infrastructure.Data.Repositories;

public class TodoTaskRepository(TodoTaskServiceContext context) : ITodoTaskRepository
{
    private readonly TodoTaskServiceContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public async Task<TodoTask?> GetTaskById(Guid id)
    {
        return await _context.TodoTasks.FirstOrDefaultAsync(x => x.Identity.Reference == id);
    }

    public async Task Save(TodoTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        var taskInDb = await GetTaskById(task.Identity.Reference);

        if (taskInDb != null)
            _context.Entry(taskInDb).CurrentValues.SetValues(task);
        else
            await _context.TodoTasks.AddAsync(task);
            
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoTask>> GetAllTasks()
    {
        return await _context.TodoTasks.ToListAsync();
    }

    public async Task AddTask(TodoTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        await _context.TodoTasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTask(TodoTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        var taskInDb = await GetTaskById(task.Identity.Reference);

        if (taskInDb != null)
        {
            _context.Entry(taskInDb).CurrentValues.SetValues(task);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveTask(Guid id)
    {
        var task = await GetTaskById(id);
        if (task != null)
        {
            _context.TodoTasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}