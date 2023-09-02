using TdpShop.Services.CouponApi.Models.Dto;

namespace TdpShop.Services.CouponApi;

public interface ICouponServices
{
    Task<List<CouponDto>> GetAllCouponDtos();
}