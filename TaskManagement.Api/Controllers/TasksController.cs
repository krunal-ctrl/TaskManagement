using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTask(int id)
    {
        var task = await taskService.GetTaskAsync(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpGet("employee/{employeeId:int}")]
    public async Task<IActionResult> GetTasksByEmployee(int employeeId)
    {
        var tasks = await taskService.GetTasksByEmployeeAsync(employeeId);
        return Ok(tasks);
    }

    [HttpGet("team/{teamId:int}")]
    public async Task<IActionResult> GetTasksByTeam(int teamId)
    {
        var tasks = await taskService.GetTasksByTeamAsync(teamId);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] CreateTaskDto createTaskDto)
    {
        await taskService.AddTaskAsync(createTaskDto);
        return CreatedAtAction(nameof(GetTask), new { id = createTaskDto.Id }, createTaskDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
    {
        if (id != taskDto.Id) return BadRequest();
        await taskService.UpdateTaskAsync(taskDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await taskService.DeleteTaskAsync(id);
        return NoContent();
    }
    [HttpPost("{taskId}/notes")]
    public async Task<IActionResult> AddNoteToTask(int taskId, [FromBody] NoteDto noteDto)
    {
        await taskService.AddNoteAsync(taskId, noteDto);
        return Ok();
    }

    [HttpPost("{taskId}/documents")]
    public async Task<IActionResult> AddDocumentToTask(int taskId, [FromForm] DocumentDto documentDto)
    {
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
        await taskService.AddDocumentAsync(taskId, documentDto, uploadPath);
        return Ok();
    }

    [HttpPost("{taskId}/complete")]
    public async Task<IActionResult> CompleteTask(int taskId)
    {
        await taskService.CompleteTaskAsync(taskId);
        return Ok();
    }
    
    [Authorize(Roles = "Manager,Admin")]
    [HttpGet("team-tasks")]
    public async Task<IActionResult> GetTeamTasks(int managerId)
    {
        var tasks = await taskService.GetTeamTasksAsync(managerId);
        return Ok(tasks);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("reports")]
    public async Task<IActionResult> GetTaskReports([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var reports = await taskService.GetTaskReportsAsync(fromDate, toDate);
        return Ok(reports);
    }
}