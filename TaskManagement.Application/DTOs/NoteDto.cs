using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs;

public class NoteDto
{
    [Required]
    [StringLength(1000, ErrorMessage = "Note content cannot exceed 1000 characters.")]
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}