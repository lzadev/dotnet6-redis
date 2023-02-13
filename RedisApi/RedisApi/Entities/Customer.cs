using System;
using System.Collections.Generic;

namespace RedisApi.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleInitial { get; set; }
        public string LastName { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
