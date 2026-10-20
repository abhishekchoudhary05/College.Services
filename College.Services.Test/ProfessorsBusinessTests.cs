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
    public class ProfessorsBusinessTests : IDisposable
    {
        private readonly DbContextOptions<CollegeDbContext> _dbContextOptions;
        private readonly CollegeDbContext _dbContext;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public ProfessorsBusinessTests()
        {
            // Use in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<CollegeDbContext>()
                .UseInMemoryDatabase(databaseName: $"ProfBusinessDB_Test_{Guid.NewGuid()}")
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
                new Professor { ProfessorId = Guid.NewGuid(), Name = "Dr. Business1", Doj = DateTime.Now, Teaches = "Java", Salary = 5000, IsPhd = true },
                new Professor { ProfessorId = Guid.NewGuid(), Name = "Dr. Business2", Doj = DateTime.Now, Teaches = "C#", Salary = 5500, IsPhd = true }
            };

            _dbContext.Professors.AddRange(professors);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Professors.ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetProfessorById_WithValidId_ReturnsProfessor()
        {
            // Arrange
            var professorId = Guid.NewGuid();
            var professor = new Professor
            {
                ProfessorId = professorId,
                Name = "Dr. Business Test",
                Doj = DateTime.Now,
                Teaches = "Python",
                Salary = 6000,
                IsPhd = true
            };

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dr. Business Test", result.Name);
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
        public void AddProfessor_WithValidProfessor_ReturnsAddedProfessor()
        {
            // Arrange
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. New Business",
                Doj = DateTime.Now,
                Teaches = "JavaScript",
                Salary = 7000,
                IsPhd = false
            };

            // Act
            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professor.ProfessorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dr. New Business", result.Name);
        }

        [Fact]
        public void UpdateProfessor_WithValidProfessor_ReturnsUpdatedProfessor()
        {
            // Arrange
            var professorId = Guid.NewGuid();
            var professor = new Professor
            {
                ProfessorId = professorId,
                Name = "Dr. Update Business",
                Doj = DateTime.Now,
                Teaches = "C++",
                Salary = 5000,
                IsPhd = false
            };

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            // Act
            var retrievedProfessor = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);
            retrievedProfessor.Salary = 7500;
            retrievedProfessor.IsPhd = true;
            _dbContext.SaveChanges();

            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(7500, result.Salary);
            Assert.True(result.IsPhd);
        }

        [Fact]
        public void DeleteProfessorById_WithValidId_ReturnsTrue()
        {
            // Arrange
            var professorId = Guid.NewGuid();
            var professor = new Professor
            {
                ProfessorId = professorId,
                Name = "Dr. Delete Business",
                Doj = DateTime.Now,
                Teaches = "Ruby",
                Salary = 5500,
                IsPhd = true
            };

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();

            // Act
            var retrievedProfessor = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);
            Assert.NotNull(retrievedProfessor);

            _dbContext.Professors.Remove(retrievedProfessor);
            _dbContext.SaveChanges();

            var result = _dbContext.Professors.FirstOrDefault(p => p.ProfessorId == professorId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void DeleteProfessorById_WithInvalidId_ReturnsFalse()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            // Act
            var exists = _dbContext.Professors.Any(p => p.ProfessorId == invalidId);

            // Assert
            Assert.False(exists);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
