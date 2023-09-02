using Microsoft.EntityFrameworkCore;
using TdpShop.Services.CouponApi.Models;

namespace TdpShop.Services.CouponApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public required DbSet<Coupon?> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}