using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace Common;

public static class AutoMapperExtensions
{
    //IServiceProvider是system接口
    private static IServiceProvider _serviceProvider;

    public static void UseAutoMapper(this IServiceProvider serviceProvider)//拓展方法
    {
        _serviceProvider = serviceProvider;
    }

    public static TDestination MapTo<TDestination>(this object source)
    {
        //DependencyInjection拓展了GetRequiredService方法
        //AutoMapper 实现IMapper类
        var mapper = _serviceProvider.GetRequiredService<IMapper>();
        return mapper.Map<TDestination>(source);
    }
    public static List<TDestnation> MapToList<TDestnation>(this IEnumerable source)
    {
        var mapper = _serviceProvider.GetRequiredService<IMapper>();
        return mapper.Map<List<TDestnation>>(source);
    }
}
