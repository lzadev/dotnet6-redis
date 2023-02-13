using AutoMapper;
using RedisApi.Dtos;
using RedisApi.Entities;

namespace RedisApi.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleDto>()
                .ForMember(dst => dst.Customer, src => src.MapFrom(x => $"{x.Customer.FirstName} {x.Customer.LastName}"))
                .ForMember(dst => dst.Seller, src => src.MapFrom(x => $"{x.SalesPerson.FirstName} {x.SalesPerson.LastName}"))
                .ForMember(dst => dst.ProductName, src => src.MapFrom(x => x.Product.Name))
                .ForMember(dst => dst.Price, src => src.MapFrom(x => x.Product.Price))
                .ForMember(dst => dst.Total, src => src.MapFrom(x => x.Product.Price * x.Quantity));

        }
    }
}
