using System.ComponentModel.DataAnnotations;

namespace TdpShop.Services.CouponApi.Models;

public class Coupon
{
    [Key] public int CouponId { get; set; }

    public required string CouponCode { get; set; }

    public required double DiscountAmount { get; set; }

    public int MinAmount { get; set; }
}