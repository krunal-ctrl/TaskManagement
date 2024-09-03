using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class EmployeeRepository(TaskManagementDbContext context): IEmployeeRepository
{
    public async Task<Employee?> GetEmployee(string username, string password)
    {
        return await context.Employees
            .Include(e => e.Role)
            .SingleOrDefaultAsync(e => e.Name == username && e.Password == password);
    }
}