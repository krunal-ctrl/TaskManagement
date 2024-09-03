using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> GetEmployee(string username, string password);
}