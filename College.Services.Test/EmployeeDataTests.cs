using College.Services.Data;
using College.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace College.Services.Test
{
    public class EmployeeDataTests : IDisposable
    {
        private readonly DbContextOptions<CollegeDbContext> _dbContextOptions;
        private readonly CollegeDbContext _dbContext;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public EmployeeDataTests()
        {
            // Use in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<CollegeDbContext>()
                .UseInMemoryDatabase(databaseName: $"EmployeeDB_Test_{Guid.NewGuid()}")
                .Options;

            _dbContext = new CollegeDbContext(_dbContextOptions);
            _mockConfiguration = new Mock<IConfiguration>();
        }

        [Fact]
        public void GetEmployees_ReturnsAllEmployees()
        {
            // Arrange
            var employees = new List<Employees>
            {
                new Employees { Id = Guid.NewGuid(), Name = "John Doe", Gender = "Male", Salary = 50000 },
                new Employees { Id = Guid.NewGuid(), Name = "Jane Smith", Gender = "Female", Salary = 55000 }
            };

            _dbContext.Employees.AddRange(employees);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Employees.ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetEmployeesById_WithValidId_ReturnsEmployee()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employee = new Employees
            {
                Id = employeeId,
                Name = "Test Employee",
                Gender = "Male",
                Salary = 60000
            };

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Employees.FirstOrDefault(e => e.Id == employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Employee", result.Name);
            Assert.Equal(employeeId, result.Id);
        }

        [Fact]
        public void GetEmployeesById_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            // Act
            var result = _dbContext.Employees.FirstOrDefault(e => e.Id == invalidId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetEmployees_WithEmptyTable_ReturnsEmptyList()
        {
            // Act
            var result = _dbContext.Employees.ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetEmployeesById_WithNullCheck_ReturnsNull()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            // Act
            var exists = _dbContext.Employees.Any(e => e.Id == employeeId);

            // Assert
            Assert.False(exists);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}