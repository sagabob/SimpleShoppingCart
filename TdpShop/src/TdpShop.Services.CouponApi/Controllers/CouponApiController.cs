using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TdpShop.Services.CouponApi.Models.Dto;
using TdpShop.Services.CouponApi.Services;

namespace TdpShop.Services.CouponApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponApiController : ControllerBase
{
    private readonly ICouponServices _couponServices;
    private readonly IMapper _mapper;

    public CouponApiController(ICouponServices couponServices, IMapper mapper)
    {
        _couponServices = couponServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var allCoupons = await _couponServices.GetAllCoupons();
        return Ok(_mapper.Map<List<CouponDto>>(allCoupons));
    }
}