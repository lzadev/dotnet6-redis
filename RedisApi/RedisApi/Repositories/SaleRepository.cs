using Microsoft.EntityFrameworkCore;
using RedisApi.Entities;
using RedisApi.Repositories.Contracts;
using System.Linq.Expressions;
using Zsoft.GenericRepositoryLibrary;

namespace RedisApi.Repositories
{
    public class SaleRepository : GenericRepository<ApplicationDbContext, Sale>, ISalesRespository
    {
        public SaleRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Sale>> GetAllIncludingTest(params Expression<Func<Sale, object>>[] includes)
        {
            IQueryable<Sale> seed = Table.AsQueryable();
            return await Task.FromResult(includes.Aggregate(seed, (IQueryable<Sale> current, Expression<Func<Sale, object>> includeProperty) => current.Include(includeProperty)).Take(5000));
        }

    }
}
