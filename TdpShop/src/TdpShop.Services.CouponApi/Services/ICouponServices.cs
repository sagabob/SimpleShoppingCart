using TdpShop.Services.CouponApi.Models;

namespace TdpShop.Services.CouponApi.Services;

public interface ICouponServices
{
    Task<List<Coupon>> GetAllCoupons();
}