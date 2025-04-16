using AutoMapper;
using WiseCart.Application.DTOs;
using WiseCart.Domain.Entities;

namespace WiseCart.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Shopping, ShoppingDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Market, MarketDTO>().ReverseMap();
            CreateMap<MarketXUser, MarketXUserDTO>().ReverseMap();
            CreateMap<Purchase, PurchaseDTO>().ReverseMap();
            CreateMap<UnitOfMeasure, UnitOfMeasureDTO>().ReverseMap();
        }
    }
}
