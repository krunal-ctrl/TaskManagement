namespace TaskManagement.Application.DTOs;

public class TaskReportDto
{
    public int EmployeeId { get; set; }
    public int CompletedTasks { get; set; }
    public int TotalTasks { get; set; }
}