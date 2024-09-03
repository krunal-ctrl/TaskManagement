using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

public interface IEmployeeService
{
    Task<Employee?> GetEmployee(string username, string password);
}