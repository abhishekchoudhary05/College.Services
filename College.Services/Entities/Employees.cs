using System;

namespace College.Services.Entities
{
    public class Employees
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
