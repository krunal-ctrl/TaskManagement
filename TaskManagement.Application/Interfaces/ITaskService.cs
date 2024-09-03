using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto> GetTaskAsync(int taskId);
    Task<IEnumerable<TaskDto>> GetTasksByEmployeeAsync(int employeeId);
    Task<IEnumerable<TaskDto>> GetTasksByTeamAsync(int teamId);
    Task AddTaskAsync(CreateTaskDto createTaskDto);
    Task UpdateTaskAsync(TaskDto taskDto);
    Task DeleteTaskAsync(int taskId);
    Task AddNoteAsync(int taskId, NoteDto noteDto);
    Task AddDocumentAsync(int taskId, DocumentDto documentDto, string uploadPath);
    Task CompleteTaskAsync(int taskId);
    Task<IEnumerable<TaskDto>> GetTeamTasksAsync(int managerId);
    Task<IEnumerable<TaskReportDto>> GetTaskReportsAsync(DateTime fromDate, DateTime toDate);
}