namespace TaskManagement.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}