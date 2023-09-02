using TdpShop.Web.Models;

namespace TdpShop.Web.Services;

public interface ICouponServices
{
    Task<CouponDto> CreateCouponsAsync(CouponDto couponDto);
    Task<CouponDto> DeleteCouponsAsync(Guid id);
    Task<CouponDto> GetCouponByCodeAsync(string couponCode);
    Task<CouponDto> GetCouponByIdAsync(Guid couponId);
    Task<bool> UpdateCouponsAsync(CouponDto couponDto);
    Task<List<CouponDto>> GetAllCouponsAsync();
}