using College.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College.Services.Data
{
    public class EmployeeData : IEmployeeData
    {
        private readonly CollegeDbContext _collegeDbContext;

        public EmployeeData(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public List<Employees> GetEmployees()
        {
            return _collegeDbContext.Employees.ToList();
        }

        public Employees GetEmployeesById(Guid id)
        {
            if (!_collegeDbContext.Employees.Any( x => x.Id == id))
            {
                return null;
            }

            return _collegeDbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
