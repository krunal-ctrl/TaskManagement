namespace TaskManagement.Domain.Entities;
public class UserTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } // Open, In Progress, Completed
    public int AssignedTo { get; set; } // Employee ID
    public int CreatedBy { get; set; } // Employee ID
    public ICollection<Note> Notes { get; set; }
    public ICollection<Document> Documents { get; set; }
}
