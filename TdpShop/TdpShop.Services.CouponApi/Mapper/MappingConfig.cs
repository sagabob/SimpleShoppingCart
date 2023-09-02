using AutoMapper;
using TdpShop.Services.CouponApi.Models;
using TdpShop.Services.CouponApi.Models.Dto;

namespace TdpShop.Services.CouponApi.Mapper;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CouponDto, Coupon>();
            config.CreateMap<Coupon, CouponDto>();
        });
        return mappingConfig;
    }
}