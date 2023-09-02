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

    public async Task<List<Coupon?>> GetAllCoupons()
    {
        return await _db.Coupons.ToListAsync();
    }

    public async Task<Coupon?> GetById(int id)
    {
        return await _db.Coupons.Where(x => x != null && x.CouponId == id).FirstOrDefaultAsync();
    }

    public async Task<Coupon?> GetByCode(string code)
    {
        return await _db.Coupons.Where(x => x != null && x.CouponCode == code).FirstOrDefaultAsync();
    }
}