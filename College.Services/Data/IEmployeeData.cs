using College.Services.Entities;
using System;
using System.Collections.Generic;

namespace College.Services.Data
{
    public interface IEmployeeData
    {
        List<Employees> GetEmployees();
        Employees GetEmployeesById(Guid id);
    }
}
