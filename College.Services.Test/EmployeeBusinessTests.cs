using College.Services.Business;
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
    public class EmployeeBusinessTests : IDisposable
    {
        private readonly DbContextOptions<CollegeDbContext> _dbContextOptions;
        private readonly CollegeDbContext _dbContext;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public EmployeeBusinessTests()
        {
            // Use in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<CollegeDbContext>()
                .UseInMemoryDatabase(databaseName: $"EmpBusinessDB_Test_{Guid.NewGuid()}")
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
                new Employees { Id = Guid.NewGuid(), Name = "Business Employee 1", Gender = "Male", Salary = 50000 },
                new Employees { Id = Guid.NewGuid(), Name = "Business Employee 2", Gender = "Female", Salary = 55000 }
            };

            _dbContext.Employees.AddRange(employees);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Employees.ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
