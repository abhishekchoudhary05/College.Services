using College.Services.Data;
using College.Services.Entities;
using System;
using System.Collections.Generic;

namespace College.Services.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeBusiness(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public List<Employees> GetEmployees()
        {
            return _employeeData.GetEmployees();
        }

        public Employees GetEmployeesById(Guid id)
        {
            return _employeeData.GetEmployeesById(id);
        }
    }
}
