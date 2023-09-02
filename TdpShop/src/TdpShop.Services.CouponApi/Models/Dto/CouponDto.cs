namespace TdpShop.Services.CouponApi.Models.Dto;

public class CouponDto
{
    public Guid CouponId { get; set; }
    public required string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}