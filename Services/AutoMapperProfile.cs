global using Repositories;
global using Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

//类型转换时候的处理
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ShopModel, ShopEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=>Guid.NewGuid()))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.ToSHA512()));
    }
}
