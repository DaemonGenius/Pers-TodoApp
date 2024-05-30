using Microsoft.EntityFrameworkCore;
using TaskService.Domain;

namespace TaskService.Infrastructure.Database.Task;

public class TaskRepository(TaskServiceContext context) : ITaskRepository
{
    private readonly TaskServiceContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<TaskState?> FetchOrDefault(TaskIdentity identity)
    {
        return await _context.Tasks.FirstOrDefaultAsync(x => x.Identity == identity);
    }

    public TaskState Initialize()
    {
        return new TaskState(new TaskIdentity(NextIdentity()));
    }

    public async System.Threading.Tasks.Task Save(TaskState state)
    {
        // Fetch the state based on the identity of the aggregate
        if (state == null)
            throw new ArgumentNullException(nameof(state));

        var stateInDb = await FetchOrDefault(state.Identity);

        if (stateInDb != null)
            _context.Entry(stateInDb).CurrentValues.SetValues(state);
        else
            await _context.Tasks.AddAsync(state);
        await _context.SaveChangesAsync();
    }
    
    private Guid NextIdentity()
    {
        return Guid.NewGuid();
    }
}