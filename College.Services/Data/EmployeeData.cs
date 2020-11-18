using College.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College.Services.Data
{
    public class EmployeeData
    {
        private readonly CollegeDbContext _collegeDbContext;

        public EmployeeData(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CollegeDbContext>();

            var connectionString = configuration["ConnectionStrings:CollegeDBConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);

            _collegeDbContext = new CollegeDbContext(optionsBuilder.Options);
        }

        internal List<Employees> GetEmployees()
        {
            return _collegeDbContext.Employees.ToList();
        }

        internal Employees GetEmployeesById(Guid id)
        {
            if (!_collegeDbContext.Employees.Any( x => x.Id == id))
            {
                return null;
            }

            return _collegeDbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
