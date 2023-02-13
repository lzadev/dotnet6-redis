using Microsoft.EntityFrameworkCore;
using RedisApi.Entities;
using RedisApi.Repositories.Contracts;
using Zsoft.GenericRepositoryLibrary;

namespace RedisApi.Repositories
{
    public class CustomerRepository : GenericRepository<ApplicationDbContext, Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Customer>> GetAllAsync()
        {

            var result = await Table.ToListAsync();
            return result;
        }
    }
}
