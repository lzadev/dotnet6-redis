using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisApi.Dtos;
using RedisApi.Entities;
using RedisApi.Repositories.Contracts;
using System.Linq;
using System.Linq.Expressions;

namespace RedisApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRespository _salesRespository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public SalesController(ISalesRespository salesRespository, IMapper mapper, IDistributedCache cache)
        {
            _salesRespository = salesRespository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet(Name = "GetAllSale")]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetAll()
        {
            //ThreadPool.SetMinThreads(100, 100);
            const string cacheKey = "getall-sales";

            IEnumerable<SaleDto> sales = await _cache.GetCacheAsync<IEnumerable<SaleDto>>(cacheKey);

            if (sales is not null) return Ok(sales);

            sales = _mapper.Map<IEnumerable<SaleDto>>(await _salesRespository.GetAllIncludingTest(x => x.Customer, x => x.Product, x => x.SalesPerson));

            _cache.SetCacheSync(cacheKey, sales.Take(500000), TimeSpan.FromMinutes(60), TimeSpan.FromMinutes(3));

            return Ok(sales);
        }
    }
}
