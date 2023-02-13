using AutoMapper;
using RedisApi.Dtos;
using RedisApi.Entities;

namespace RedisApi.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
