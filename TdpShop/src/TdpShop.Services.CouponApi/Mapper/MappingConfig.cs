using AutoMapper;
using TdpShop.Services.CouponApi.Models;
using TdpShop.Services.CouponApi.Models.Dto;

namespace TdpShop.Services.CouponApi.Mapper;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<CouponDto, Coupon>().ReverseMap();
    }
}