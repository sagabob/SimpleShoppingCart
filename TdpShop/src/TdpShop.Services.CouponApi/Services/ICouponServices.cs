using TdpShop.Services.CouponApi.Models;

namespace TdpShop.Services.CouponApi.Services;

public interface ICouponServices
{
    Task<List<Coupon>> GetAllCoupons();

    Task<Coupon?> GetById(Guid id);

    Task<Coupon?> GetByCode(string code);

    Task AddCoupon(Coupon coupon);

    Task UpdateCoupon(Coupon coupon);
}