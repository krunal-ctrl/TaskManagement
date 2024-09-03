using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository): IEmployeeService
{
    public async Task<Employee?> GetEmployee(string username, string password)
    {
        return await employeeRepository.GetEmployee(username, password);
    }
}