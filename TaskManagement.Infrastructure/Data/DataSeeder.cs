using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data;

public class DataSeeder(TaskManagementDbContext context)
{
    public void Seed()
    {
        // Seed Roles
        if (!context.Roles.Any())
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Manager" },
                new Role { Name = "Employee" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }

        // Seed Employees
        if (!context.Employees.Any())
        {
            var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");
            var managerRole = context.Roles.FirstOrDefault(r => r.Name == "Manager");

            var employees = new List<Employee>
            {
                new Employee { Name = "Alice", Role = adminRole, Password = "123" },
                new Employee { Name = "Bob", Role = managerRole, Password = "123" },
                new Employee { Name = "Charlie", Role = adminRole, Password = "123" }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}