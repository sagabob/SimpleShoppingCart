using Microsoft.AspNetCore.Mvc;
using TdpShop.Services.CouponApi.Models.Dto;

namespace TdpShop.Services.CouponApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponApiController : ControllerBase
{
    private readonly ICouponServices _couponServices;

    public CouponApiController(ICouponServices couponServices)
    {
        _couponServices = couponServices;
    }

    [HttpGet]
    public async Task<List<CouponDto>> Get()
    {
        return await _couponServices.GetAllCouponDtos();
    }
}