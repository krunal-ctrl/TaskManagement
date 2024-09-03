using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository(TaskManagementDbContext context) : ITaskRepository
{
    public async Task<UserTask> GetTaskAsync(int taskId)
    {
        return await context.Tasks
            .Include(t => t.Notes)
            .Include(t => t.Documents)
            .FirstOrDefaultAsync(t => t.Id == taskId);
    }

    public async Task<IEnumerable<UserTask?>> GetTasksByEmployeeAsync(int employeeId)
    {
        return await context.Tasks.Where(t => t.AssignedTo == employeeId).ToListAsync();
    }

    public async Task<IEnumerable<UserTask?>> GetTasksByTeamAsync(int teamId)
    {
        // Assuming TeamId is a property of Employee or you can join with Employee Table
        return await context.Tasks.Where(t => t.AssignedTo == teamId).ToListAsync();
    }

    public async Task AddTaskAsync(UserTask? task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(UserTask? task)
    {
        context.Tasks.Update(task);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var task = await context.Tasks.FindAsync(taskId);
        if (task != null)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<UserTask>> GetTasksByManagerIdAsync(int managerId)
    {
        return await context.Tasks
            .Where(t => t.CreatedBy == managerId)
            .Include(t => t.Notes)
            .Include(t => t.Documents)
            .ToListAsync();
    }

    public async Task<List<UserTask>> GetTasksByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        return await context.Tasks
            .Where(t => t.DueDate >= fromDate && t.DueDate <= toDate)
            .Include(t => t.Notes)
            .Include(t => t.Documents)
            .ToListAsync();
    }
}