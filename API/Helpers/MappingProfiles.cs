using API.Dtos;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entitties;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<product,ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s=> s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s=> s.ProductType.Name))
                .ForMember(d => d.PictureUrl , o =>o.MapFrom<ProductUrlResolver>());
            CreateMap<Address,AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDTO,CustomerBasket>();
            CreateMap<BasketItemDTO,BasketItem>(); 
        }
    }
}