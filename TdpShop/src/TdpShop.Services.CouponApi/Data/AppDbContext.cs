using Microsoft.EntityFrameworkCore;
using TdpShop.Services.CouponApi.Models;

namespace TdpShop.Services.CouponApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public required DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            CouponId = Guid.NewGuid(),
            CouponCode = "10OFF",
            DiscountAmount = 10,
            MinAmount = 20
        });


        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            CouponId = Guid.NewGuid(),
            CouponCode = "20OFF",
            DiscountAmount = 20,
            MinAmount = 40
        });
    }
}