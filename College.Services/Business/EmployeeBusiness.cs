using College.Services.Data;
using College.Services.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace College.Services.Business
{
    public class EmployeeBusiness
    {
        private readonly EmployeeData _employeeData;

        public EmployeeBusiness(IConfiguration configuration)
        {
            _employeeData = new EmployeeData(configuration);
        }

        internal List<Employees> GetEmployees()
        {
            return _employeeData.GetEmployees();
        }

        internal Employees GetEmployeesById(Guid id)
        {
            return _employeeData.GetEmployeesById(id);
        }
    }
}
