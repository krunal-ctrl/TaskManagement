namespace TaskManagement.Domain.Entities;

public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int TaskId { get; set; }
    public UserTask UserTask { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}