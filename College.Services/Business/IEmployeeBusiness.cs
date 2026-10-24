using College.Services.Entities;
using System;
using System.Collections.Generic;

namespace College.Services.Business
{
    public interface IEmployeeBusiness
    {
        List<Employees> GetEmployees();
        Employees GetEmployeesById(Guid id);
    }
}
