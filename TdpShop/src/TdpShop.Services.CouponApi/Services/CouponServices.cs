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
        return await _db.Coupons.AsNoTracking().ToListAsync();
    }

    public async Task<Coupon?> GetById(Guid id)
    {
        return await _db.Coupons.AsNoTracking().Where(x => x!.CouponId == id).FirstOrDefaultAsync();
    }

    public async Task<Coupon?> GetByCode(string code)
    {
        return await _db.Coupons.AsNoTracking().Where(x => x!.CouponCode == code).FirstOrDefaultAsync();
    }

    public async Task AddCoupon(Coupon coupon)
    {
        _db.Coupons.Add(coupon);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateCoupon(Coupon coupon)
    {
        _db.Entry(coupon).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCoupon(Coupon coupon)
    {
        _db.Coupons.Remove(coupon);
        await _db.SaveChangesAsync();
    }
}