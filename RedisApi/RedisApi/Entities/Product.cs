using System;
using System.Collections.Generic;

namespace RedisApi.Entities
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
