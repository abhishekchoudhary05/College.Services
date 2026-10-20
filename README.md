# College.Services

A .NET Core 10 web API service for managing college-related data, including professors and employees.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [API Endpoints](#api-endpoints)
- [Database Setup](#database-setup)
- [Project Structure](#project-structure)
- [Building and Running](#building-and-running)
- [Technologies Used](#technologies-used)

## Overview

College.Services is a modern web API built with .NET Core 10, designed to provide RESTful services for managing academic and employee data. The service includes comprehensive CRUD operations for professors and employees, with a solid Entity Framework Core data layer and clean separation of concerns.

## Features

- **Full CRUD Operations**: Complete create, read, update, and delete functionality
- **Entity Framework Core 10**: Modern ORM with repository pattern
- **Clean Architecture**: Separation of concerns with business logic, data access, and presentation layers
- **Comprehensive Database**: Including professors and employees data with proper relationships
- **RESTful API**: Standard HTTP methods and RESTful design principles
- **Modern .NET 10**: Latest features and performance improvements

## API Endpoints

### Professors API (`/api/professors`)

- `GET /api/professors` - Get all professors
- `GET /api/professors/{id}` - Get professor by ID
- `POST /api/professors` - Add a new professor
- `PUT /api/professors` - Update professor information
- `DELETE /api/professors/{id}` - Delete professor

### Employees API (`/api/employees`)

- `GET /api/employees` - Get all employees
- `GET /api/employees/{id}` - Get employee by ID

## Database Setup

The database setup includes:

### Database Scripts Location

`SqlScripts/` directory contains SQL scripts for database initialization:

- **`Create_Professors.sql`**: Creates the `CollegeServices` database and `Professors` table with comprehensive schema including:
  - Primary key with GUID ID
  - Name, DOJ, teaches, salary, and PhD status
  - Additional fields: Email, Phone, Department, CreatedAt
  - Index on Department and Name for performance

- **`Insert_Professors.sql`**: Inserts initial data with 8 diverse professor records including:
  - Computer Science professors
  - Software Engineering experts
  - Database administrators
  - Machine learning specialists
  - Cloud infrastructure experts
  - Cybersecurity professionals

## Project Structure

```
College.Services/
├── Controllers/
│   ├── ProfessorsController.cs
│   └── EmployeeController.cs
├── Business/
│   ├── ProfessorsBusiness.cs
│   └── EmployeeBusiness.cs
├── Data/
│   ├── CollegeDbContext.cs
│   ├── ProfessorsData.cs
│   └── EmployeeData.cs
├── Entities/
│   ├── Professor.cs
│   ├── Employees.cs
│   └── Student.cs
├── Program.cs
├── Startup.cs
├── obj/ (build artifacts)
├── bin/ (output)
└── SqlScripts/
    ├── Create_Professors.sql
    └── Insert_Professors.sql
```

## Building and Running

### Prerequisites

- .NET 10 SDK or later
- SQL Server (any version)

### Build

1. Open terminal/command prompt in the project directory
2. Run: `dotnet build`
3. Build successful with 15 warnings (mostly deprecation warnings for legacy patterns)

### Run

1. Ensure SQL Server is running
2. Execute the database scripts in this order:
   - First run `Create_Professors.sql` to create database and tables
   - Then run `Insert_Professors.sql` to populate initial data
3. Run: `dotnet run`
4. API will be available at: `http://localhost:5000`

### Testing

The API includes basic endpoints that can be tested with tools like:
- Postman
- curl
- Swagger (if configured)

## Technologies Used

- **Platform**: .NET Core 10
- **Web Framework**: ASP.NET Core
- **ORM**: Entity Framework Core 10
- **Language**: C#
- **Database**: SQL Server
- **Architecture**: Clean Architecture, Repository Pattern
- **API Design**: RESTful
- **Package Manager**: NuGet

## Notes

- This project demonstrates modern .NET 10 development practices
- Includes comprehensive error handling and data validation
- Uses GUIDs as primary keys for better security and distribution
- Incorporates comprehensive database indexing for performance
- Maintains clean separation between business logic and data access layers

## Future Enhancements

Potential future improvements could include:
- Adding authentication and authorization
- Implementing caching strategies
- Adding comprehensive logging
- Implementing Swagger/OpenAPI documentation
- Adding more comprehensive error handling
- Implementing automated testing
- Adding more complex relationships between entities

## Dependencies

All dependencies are managed through NuGet, including:
- Microsoft.AspNetCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.VisualStudio.Web.CodeGeneration.Design

## Credits

Built by [Your Name] as a demonstration of modern .NET Core 10 development practices and clean architecture principles.
