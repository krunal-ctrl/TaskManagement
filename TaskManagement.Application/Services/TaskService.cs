using AutoMapper;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services;

public class TaskService(ITaskRepository taskRepository, IMapper mapper) : ITaskService
{
    public async Task<TaskDto> GetTaskAsync(int taskId)
    {
        var task = await taskRepository.GetTaskAsync(taskId);
        return mapper.Map<TaskDto>(task);
    }

    public async Task<IEnumerable<TaskDto>> GetTasksByEmployeeAsync(int employeeId)
    {
        var tasks = await taskRepository.GetTasksByEmployeeAsync(employeeId);
        return mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task<IEnumerable<TaskDto>> GetTasksByTeamAsync(int teamId)
    {
        var tasks = await taskRepository.GetTasksByTeamAsync(teamId);
        return mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task AddTaskAsync(CreateTaskDto createTaskDto)
    {
        var task = mapper.Map<UserTask>(createTaskDto);
        task.Status = "Pending";
        await taskRepository.AddTaskAsync(task);
    }

    public async Task UpdateTaskAsync(TaskDto taskDto)
    {
        var task = mapper.Map<UserTask>(taskDto);
        await taskRepository.UpdateTaskAsync(task);
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        await taskRepository.DeleteTaskAsync(taskId);
    }
    
    public async Task AddNoteAsync(int taskId, NoteDto noteDto)
    {
        var task = await taskRepository.GetTaskAsync(taskId);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        var note = mapper.Map<Note>(noteDto);
        note.TaskId = taskId;
        task.Notes.Add(note);
    
        await taskRepository.UpdateTaskAsync(task);
    }
    
    public async Task AddDocumentAsync(int taskId, DocumentDto documentDto, string uploadPath)
    {
        var task = await taskRepository.GetTaskAsync(taskId);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        // Ensure the directory exists
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        // Generate a unique file name
        var uniqueFileName = $"{Guid.NewGuid()}_{documentDto.File.FileName}";
        var filePath = Path.Combine(uploadPath, uniqueFileName);

        // Save the file to the specified path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await documentDto.File.CopyToAsync(stream);
        }

        var document = new Document
        {
            FilePath = filePath,
            TaskId = taskId,
            UploadedAt = documentDto.UploadedAt
        };
    
        task.Documents.Add(document);
        await taskRepository.UpdateTaskAsync(task);
    }
    
    public async Task CompleteTaskAsync(int taskId)
    {
        var task = await taskRepository.GetTaskAsync(taskId);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        task.Status = "Completed";
        await taskRepository.UpdateTaskAsync(task);
    }
    
    public async Task<IEnumerable<TaskDto>> GetTeamTasksAsync(int managerId)
    {
        var tasks = await taskRepository.GetTasksByManagerIdAsync(managerId);
        return mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task<IEnumerable<TaskReportDto>> GetTaskReportsAsync(DateTime fromDate, DateTime toDate)
    {
        var tasks = await taskRepository.GetTasksByDateRangeAsync(fromDate, toDate);
        return tasks.GroupBy(t => t.AssignedTo)
            .Select(g => new TaskReportDto
            {
                EmployeeId = g.Key,
                CompletedTasks = g.Count(t => t.Status == "Completed"),
                TotalTasks = g.Count()
            });
    }
}