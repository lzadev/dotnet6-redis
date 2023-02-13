using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisApi.Dtos;
using RedisApi.Repositories.Contracts;

namespace RedisApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper,
            IDistributedCache cache)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            const string cacheKey = "getall-customers";

            var customers = await _cache.GetCacheAsync<IEnumerable<CustomerDto>>(cacheKey);

            if (customers is not null) return Ok(customers);

            //If not customer cached let's get them from Database

            customers = _mapper.Map<List<CustomerDto>>(await _customerRepository.GetAllAsync());

            await _cache.SetCacheAsync(cacheKey, customers, TimeSpan.FromMinutes(60), TimeSpan.FromMinutes(2));

            return Ok(customers);
        }
    }
}
