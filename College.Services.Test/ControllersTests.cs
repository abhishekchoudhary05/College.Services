using College.Services.Controllers;
using College.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace College.Services.Test
{
    public class ControllersTests
    {
        [Fact]
        public void ProfessorsController_Exists()
        {
            // This verifies that the ProfessorsController class exists and can be instantiated
            var controllerType = typeof(ProfessorsController);
            Assert.NotNull(controllerType);
        }

        [Fact]
        public void EmployeeController_Exists()
        {
            // This verifies that the EmployeeController class exists
            var controllerType = typeof(EmployeeController);
            Assert.NotNull(controllerType);
        }

        [Fact]
        public void ProfessorsController_GetMethod_Exists()
        {
            // Verify the Get method exists on ProfessorsController
            var method = typeof(ProfessorsController).GetMethod("Get");
            Assert.NotNull(method);
        }

        [Fact]
        public void ProfessorsController_GetProfessorById_Exists()
        {
            // Verify the GetProfessorById method exists
            var method = typeof(ProfessorsController).GetMethod("GetProfessorById");
            Assert.NotNull(method);
        }

        [Fact]
        public void ProfessorsController_AddProfessor_Exists()
        {
            // Verify the AddProfessor method exists
            var method = typeof(ProfessorsController).GetMethod("AddProfessor");
            Assert.NotNull(method);
        }

        [Fact]
        public void ProfessorsController_UpdateProfessor_Exists()
        {
            // Verify the UpdateProfessor method exists
            var method = typeof(ProfessorsController).GetMethod("UpdateProfessor");
            Assert.NotNull(method);
        }

        [Fact]
        public void ProfessorsController_DeleteProfessor_Exists()
        {
            // Verify the DeleteProfessor method exists
            var method = typeof(ProfessorsController).GetMethod("DeleteProfessor");
            Assert.NotNull(method);
        }

        [Fact]
        public void EmployeeController_GetEmployees_Exists()
        {
            // Verify GetEmployees method exists
            var method = typeof(EmployeeController).GetMethod("GetEmployees");
            Assert.NotNull(method);
        }

        [Fact]
        public void EmployeeController_GetEmployeesById_Exists()
        {
            // Verify GetEmployeesById method exists
            var method = typeof(EmployeeController).GetMethod("GetEmployeesById");
            Assert.NotNull(method);
        }

        [Fact]
        public void Professor_Entity_HasAllProperties()
        {
            // Verify Professor entity properties
            var professor = new Professor();

            // Verify properties exist by accessing them
            professor.ProfessorId = Guid.NewGuid();
            professor.Name = "Test";
            professor.Doj = DateTime.Now;
            professor.Teaches = "Test Subject";
            professor.Salary = 5000;
            professor.IsPhd = false;

            Assert.True(professor.ProfessorId != Guid.Empty);
            Assert.Equal("Test", professor.Name);
        }

        [Fact]
        public void Employee_Entity_HasAllProperties()
        {
            // Verify Employee entity properties
            var employee = new Employees();

            // Verify properties exist
            employee.Id = Guid.NewGuid();
            employee.Name = "Employee";
            employee.Gender = "Male";
            employee.Salary = 50000;

            Assert.True(employee.Id != Guid.Empty);
            Assert.Equal("Employee", employee.Name);
            Assert.Equal("Male", employee.Gender);
        }
    }
}