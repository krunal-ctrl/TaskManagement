using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task<UserTask?> GetTaskAsync(int taskId);
    Task<IEnumerable<UserTask?>> GetTasksByEmployeeAsync(int employeeId);
    Task<IEnumerable<UserTask?>> GetTasksByTeamAsync(int teamId);
    Task AddTaskAsync(UserTask? task);
    Task UpdateTaskAsync(UserTask? task);
    Task DeleteTaskAsync(int taskId);
    Task<IEnumerable<UserTask>> GetTasksByManagerIdAsync(int managerId);
    Task<List<UserTask>> GetTasksByDateRangeAsync(DateTime fromDate, DateTime toDate);
}