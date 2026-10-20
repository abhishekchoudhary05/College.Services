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
    public class ProfessorsDataTests : IDisposable
    {
        private readonly DbContextOptions<CollegeDbContext> _dbContextOptions;
        private readonly CollegeDbContext _dbContext;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public ProfessorsDataTests()
        {
            // Use in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<CollegeDbContext>()
                .UseInMemoryDatabase(databaseName: $"CollegeDB_Test_{Guid.NewGuid()}")
                .Options;

            _dbContext = new CollegeDbContext(_dbContextOptions);
            _mockConfiguration = new Mock<IConfiguration>();
        }

        [Fact]
        public void GetProfessors_ReturnsAllProfessors()
        {
            // Arrange
            var professors = new List<Professor>
            {
                new Professor { ProfessorId = Guid.NewGuid(), Name = "Dr. Smith", Doj = DateTime.Now, Teaches = "Java", Salary = 5000, IsPhd = true },
                new Professor { ProfessorId = Guid.NewGuid(), Name = "Dr. Jones", Doj = DateTime.Now, Teaches = "C#", Salary = 5500, IsPhd = true }
            };

            _dbContext.Professors.AddRange(professors);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Professors.ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, p => Assert.NotNull(p.Name));
        }

        [Fact]
        public void GetProfessorById_WithValidId_ReturnsProfessor()
        {
            // Arrange
            var professorId = Guid.NewGuid();
            var professor = new Professor
            {
                ProfessorId = professorId,
                Name = "Dr. Test",
                Doj = DateTime.Now,
                Teaches = "Python",
                Salary = 5000,
                IsPhd = true
            };

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dr. Test", result.Name);
            Assert.Equal(professorId, result.ProfessorId);
        }

        [Fact]
        public void GetProfessorById_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            // Act
            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == invalidId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddProfessor_WithValidProfessor_AddsProfessor()
        {
            // Arrange
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. New",
                Doj = DateTime.Now,
                Teaches = "JavaScript",
                Salary = 6000,
                IsPhd = false
            };

            // Act
            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professor.ProfessorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dr. New", result.Name);
            Assert.Equal(6000, result.Salary);
        }

        [Fact]
        public void UpdateProfessor_WithValidProfessor_UpdatesProfessor()
        {
            // Arrange
            var professorId = Guid.NewGuid();
            var professor = new Professor
            {
                ProfessorId = professorId,
                Name = "Dr. Update",
                Doj = DateTime.Now,
                Teaches = "C++",
                Salary = 5000,
                IsPhd = false
            };

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            // Act
            var retrievedProfessor = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);
            retrievedProfessor.Salary = 6500;
            retrievedProfessor.IsPhd = true;
            _dbContext.SaveChanges();

            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(6500, result.Salary);
            Assert.True(result.IsPhd);
        }

        [Fact]
        public void DeleteProfessor_WithValidId_DeletesProfessor()
        {
            // Arrange
            var professorId = Guid.NewGuid();
            var professor = new Professor
            {
                ProfessorId = professorId,
                Name = "Dr. Delete",
                Doj = DateTime.Now,
                Teaches = "Ruby",
                Salary = 5500,
                IsPhd = true
            };

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            // Act
            var retrievedProfessor = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);
            _dbContext.Professors.Remove(retrievedProfessor);
            _dbContext.SaveChanges();

            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void DeleteProfessor_WithInvalidId_NoErrorThrown()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            // Act & Assert
            var professor = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == invalidId);
            Assert.Null(professor);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
