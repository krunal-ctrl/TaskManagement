
# Task Management System

## Overview

The Task Management System is a web application designed to help employees track their tasks, allowing them to attach documents, add notes, and mark tasks as completed. Managers or Team Leaders can track the tasks of their team members, while the Company Admin can generate reports to assess team performance in terms of closing tasks that are due in a specific time frame.

## Features

- **Task Management**: Employees can create, update, and manage their tasks.
- **Document Upload**: Attach documents to tasks.
- **Notes**: Add notes to tasks for additional information.
- **Team Tracking**: Managers can view and track the tasks assigned to their team members.
- **Reports**: Admins can generate reports to see how teams are performing over various time periods.
- **Authorization**: Role-based access control for Employees, Managers, and Admins.

## Technologies Used

- **Backend/API**: .NET Core 7, Entity Framework Core
- **Database**: SQL Server (or other relational DB like PostgreSQL)
- **Authentication/Authorization**: ASP.NET Core Identity with role-based authorization
- **Data Validation**: Integrated using data annotations
- **File Upload**: Handled using `IFormFile` in ASP.NET Core

## Project Structure

```
TaskManagement/
│
├── TaskManagement.API/                 # API Project
│   ├── AppStart/                       # API Startup Files
│   ├── Controllers/                    # API Controllers
│   ├── Middleware/                     # API Middlewares
│   └── Program.cs                      # Application Startup
│
├── TaskManagement.Application/         # Application Layer
│   ├── DTOs/                           # Data Transfer Objects
│   ├── Models/                         # Domain Models
│   ├── Services/                       # Business Logic Layer
│   └── Mappings/                       # AutoMapper Profiles
│
├── TaskManagement.Domain/              # Domain Layer
│   ├── Entities/                       # Data Entities
│   └── Interfaces/                     # Repository Interfaces
│
└── TaskManagement.Infrastructure/      # Data Layer
    ├── Data/                           # Data Access Layer
    │   ├── TaskManagementDbContext.cs  # Database Context
    │   └── SeedData.cs                 # Seed data for roles
    ├── Migrations/                     # EF Core Migrations
    └── Repositories/                   # Data Access Layer

```

## Getting Started

### Prerequisites

- [.NET SDK 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or another relational database)
- Optional: [Postman](https://www.postman.com/) for testing APIs

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/TaskManagement.git
   cd TaskManagement
   ```

2. **Set up the database**:
    - Update the connection string in `appsettings.json` under `TaskManagement.API`.
    - Run the following command to apply migrations and seed the database:
      ```bash
      dotnet ef database update --project TaskManagement.Infrastrucure
      ```

3. **Run the application**:
   ```bash
   dotnet run --project TaskManagement.API
   ```

### API Documentation

The API is documented using Swagger. Once the application is running, you can access the Swagger UI at:

### Authorization

The application uses role-based access control with three roles:

- **Employee**: Can manage their tasks.
- **Manager**: Can manage their team's tasks.
- **Admin**: Can generate reports and manage all users.
