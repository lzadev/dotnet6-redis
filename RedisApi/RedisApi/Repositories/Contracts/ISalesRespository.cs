using RedisApi.Entities;
using System.Linq.Expressions;
using Zsoft.GenericRepositoryLibrary;

namespace RedisApi.Repositories.Contracts
{
    public interface ISalesRespository : IGenericRepository<Sale>
    {
        Task<IEnumerable<Sale>> GetAllIncludingTest(params Expression<Func<Sale, object>>[] includes);
    }
}
