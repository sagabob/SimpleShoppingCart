using TdpShop.Services.CouponApi.Models;

namespace TdpShop.Services.CouponApi.Services;

public interface ICouponServices
{
    Task<List<Coupon?>> GetAllCoupons();

    Task<Coupon?> GetById(int id);

    Task<Coupon?> GetByCode(string code);
}