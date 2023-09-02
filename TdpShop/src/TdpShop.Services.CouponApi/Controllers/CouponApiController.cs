using System.Net;
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
    [Route("all")]
    public async Task<IActionResult> GetAllCoupons()
    {
        var allCoupons = await _couponServices.GetAllCoupons();
        return Ok(_mapper.Map<List<CouponDto>>(allCoupons));
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Route("id/{id:int}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        var coupon = await _couponServices.GetById(id);

        if (coupon == null)
            return NotFound();

        return Ok(_mapper.Map<CouponDto>(coupon));
    }

    [HttpGet]
    [Route("code/{code}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCouponByCode(string code)
    {
        var coupon = await _couponServices.GetByCode(code);

        if (coupon == null)
            return NotFound();

        return Ok(_mapper.Map<CouponDto>(coupon));
    }
}