global using Model;
global using Repositories;
using AutoMapper;

namespace Services;

//类型转换时候的处理
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ShopModel, ShopEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.ToSHA512()));
        CreateMap<ShopEntity, ShopModel>();

        CreateMap<CustomerEntity, CustomerModel>();
        CreateMap<ProductEntity, ProductModel>();
        CreateMap<ProductModel, ProductEntity>();
    } 
}
