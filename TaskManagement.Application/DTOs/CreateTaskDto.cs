using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs;

public class CreateTaskDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }
    
    [Required]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public int AssignedTo { get; set; }
    [Required]
    public int CreatedBy { get; set; }
}