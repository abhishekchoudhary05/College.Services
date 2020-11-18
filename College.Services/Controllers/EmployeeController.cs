using College.Services.Business;
using College.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace College.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeBusiness _employeeBusiness;

        public EmployeeController(IConfiguration configuration)
        {
            _employeeBusiness = new EmployeeBusiness(configuration);
        }

        [HttpGet]
        public List<Employees> GetEmployees()
        {
            return _employeeBusiness.GetEmployees();
        }

        [HttpGet("{id}")]
        public Employees GetEmployeesById(Guid Id)
        {
            return _employeeBusiness.GetEmployeesById(Id);
        }
    }
}