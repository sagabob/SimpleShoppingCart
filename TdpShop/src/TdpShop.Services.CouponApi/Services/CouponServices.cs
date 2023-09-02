using Microsoft.EntityFrameworkCore;
using TdpShop.Services.CouponApi.Data;
using TdpShop.Services.CouponApi.Models;

namespace TdpShop.Services.CouponApi.Services;

public class CouponServices : ICouponServices
{
    private readonly AppDbContext _db;


    public CouponServices(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Coupon>> GetAllCoupons()
    {
        return await _db.Coupons.ToListAsync();
    }

    public async Task<Coupon?> GetById(Guid id)
    {
        return await _db.Coupons.Where(x => x!.CouponId == id).FirstOrDefaultAsync();
    }

    public async Task<Coupon?> GetByCode(string code)
    {
        return await _db.Coupons.Where(x => x!.CouponCode == code).FirstOrDefaultAsync();
    }

    public async Task AddCoupon(Coupon coupon)
    {
        _db.Coupons.Add(coupon);
        await _db.SaveChangesAsync();
    }
}