using System.Net;
using TdpShop.Web.Extensions;
using TdpShop.Web.Models;

namespace TdpShop.Web.Services.Core;

public class CouponServices : ICouponServices
{
    private readonly HttpClient _client;

    public CouponServices(HttpClient client)
    {
        _client = client;
    }

    public async Task<CouponDto> CreateCouponsAsync(CouponDto couponDto)
    {
        var couponResponse = await _client.PostAsJsonAsync("/api/coupon", couponDto);

        var postedCoupon = await couponResponse.ReadContentAs<CouponDto>();

        return postedCoupon;
    }

    public async Task<CouponDto> DeleteCouponsAsync(Guid id)
    {
        var couponResponse = await _client.DeleteAsync($"/api/coupon/{id}");

        var deletedCoupon = await couponResponse.ReadContentAs<CouponDto>();

        return deletedCoupon;
    }

    public async Task<CouponDto> GetCouponByCodeAsync(string couponCode)
    {
        var couponResponse = await _client.GetAsync($"/api/coupon/code/{couponCode}");

        var coupon = await couponResponse.ReadContentAs<CouponDto>();

        return coupon;
    }

    public async Task<CouponDto> GetCouponByIdAsync(Guid couponId)
    {
        var couponResponse = await _client.GetAsync($"/api/coupon/id/{couponId}");

        var coupon = await couponResponse.ReadContentAs<CouponDto>();

        return coupon;
    }

    public async Task<bool> UpdateCouponsAsync(CouponDto couponDto)
    {
        var couponUpdatingResponse = await _client.PutAsJsonAsync("/api/coupon", couponDto);

        return couponUpdatingResponse.StatusCode == HttpStatusCode.NoContent;
    }

    public async Task<List<CouponDto>> GetAllCouponsAsync()
    {
        var couponResponse = await _client.GetAsync("/api/coupon/all");

        var coupons = await couponResponse.ReadContentAs<List<CouponDto>>();

        return coupons;
    }
}