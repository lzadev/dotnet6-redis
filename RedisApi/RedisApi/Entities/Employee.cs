using System;
using System.Collections.Generic;

namespace RedisApi.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Sales = new HashSet<Sale>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleInitial { get; set; }
        public string LastName { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
