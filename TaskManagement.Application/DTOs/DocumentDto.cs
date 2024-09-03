using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TaskManagement.Application.DTOs;

public class DocumentDto
{
    [Required]
    public IFormFile File { get; set; }
    
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}