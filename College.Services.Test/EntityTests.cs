using College.Services.Entities;
using System;
using System.Linq;
using Xunit;

namespace College.Services.Test
{
    public class EntityTests
    {
        [Fact]
        public void Professor_CanBeCreated_WithValidData()
        {
            // Arrange & Act
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. Test Professor",
                Doj = new DateTime(2010, 1, 1),
                Teaches = "C#; Java; Python",
                Salary = 5000.00m,
                IsPhd = true
            };

            // Assert
            Assert.NotNull(professor);
            Assert.NotEqual(Guid.Empty, professor.ProfessorId);
            Assert.Equal("Dr. Test Professor", professor.Name);
            Assert.Equal(5000.00m, professor.Salary);
            Assert.True(professor.IsPhd);
            Assert.NotNull(professor.Students);
        }

        [Fact]
        public void Professor_StudentsCollection_IsInitialized()
        {
            // Act
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. Test",
                Doj = DateTime.Now,
                Teaches = "Java",
                Salary = 5000,
                IsPhd = true
            };

            // Assert
            Assert.NotNull(professor.Students);
            Assert.Empty(professor.Students);
        }

        [Fact]
        public void Professor_WithPhdFalse_IsCorrectlySet()
        {
            // Act
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. Test",
                Doj = DateTime.Now,
                Teaches = "Python",
                Salary = 5000,
                IsPhd = false
            };

            // Assert
            Assert.False(professor.IsPhd);
        }

        [Fact]
        public void Students_CanBeAddedToProfessor()
        {
            // Arrange
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. Test",
                Doj = DateTime.Now,
                Teaches = "C#",
                Salary = 5000,
                IsPhd = true
            };

            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                RollNumber = "CS001",
                Dob = new DateTime(2000, 1, 1),
                IsAthlete = false,
                Fees = 10000,
                ProfessorId = professor.ProfessorId
            };

            // Act
            professor.Students.Add(student);

            // Assert
            Assert.Single(professor.Students);
            Assert.Contains(student, professor.Students.ToList());
        }

        [Fact]
        public void Student_CanBeCreated_WithValidData()
        {
            // Arrange & Act
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                RollNumber = "CS002",
                Dob = new DateTime(2001, 5, 15),
                IsAthlete = true,
                Fees = 15000
            };

            // Assert
            Assert.NotNull(student);
            Assert.NotEqual(Guid.Empty, student.Id);
            Assert.Equal("Jane Doe", student.Name);
            Assert.Equal("CS002", student.RollNumber);
            Assert.True(student.IsAthlete);
        }

        [Fact]
        public void Employees_CanBeCreated_WithValidData()
        {
            // Arrange & Act
            var employee = new Employees
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Gender = "Male",
                Salary = 75000.00m
            };

            // Assert
            Assert.NotNull(employee);
            Assert.NotEqual(Guid.Empty, employee.Id);
            Assert.Equal("John Smith", employee.Name);
            Assert.Equal("Male", employee.Gender);
            Assert.Equal(75000.00m, employee.Salary);
        }

        [Fact]
        public void Professor_WithMultipleStudents_HasCorrectCount()
        {
            // Arrange
            var professor = new Professor
            {
                ProfessorId = Guid.NewGuid(),
                Name = "Dr. Test",
                Doj = DateTime.Now,
                Teaches = "Math",
                Salary = 5000,
                IsPhd = true
            };

            // Act
            professor.Students.Add(new Student
            {
                Id = Guid.NewGuid(),
                Name = "Student 1",
                RollNumber = "S001",
                Dob = DateTime.Now,
                IsAthlete = false,
                Fees = 10000
            });

            professor.Students.Add(new Student
            {
                Id = Guid.NewGuid(),
                Name = "Student 2",
                RollNumber = "S002",
                Dob = DateTime.Now,
                IsAthlete = true,
                Fees = 12000
            });

            professor.Students.Add(new Student
            {
                Id = Guid.NewGuid(),
                Name = "Student 3",
                RollNumber = "S003",
                Dob = DateTime.Now,
                IsAthlete = false,
                Fees = 11000
            });

            // Assert
            Assert.Equal(3, professor.Students.Count);
        }
    }
}