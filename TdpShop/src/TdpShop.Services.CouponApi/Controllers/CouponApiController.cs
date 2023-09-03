using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TdpShop.Services.CouponApi.Models;
using TdpShop.Services.CouponApi.Models.Dto;
using TdpShop.Services.CouponApi.Services;

namespace TdpShop.Services.CouponApi.Controllers;

[Route("api/coupon")]
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
        Log.Information("Get all coupons");
        var allCoupons = await _couponServices.GetAllCoupons();
        return Ok(_mapper.Map<List<CouponDto>>(allCoupons));
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Route("id/{id}")]
    public async Task<IActionResult> GetCouponById(Guid id)
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


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CouponDto couponDto)
    {
        var inputCoupon = _mapper.Map<Coupon>(couponDto);
        await _couponServices.AddCoupon(inputCoupon);

        return CreatedAtAction(
            nameof(GetCouponById),
            new { id = inputCoupon.CouponId },
            _mapper.Map<CouponDto>(inputCoupon));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CouponDto couponDto)
    {
        var coupon = await _couponServices.GetById(couponDto.CouponId);

        if (coupon == null)
            return NotFound();

        var inputCoupon = _mapper.Map<Coupon>(couponDto);

        await _couponServices.UpdateCoupon(inputCoupon);

        return NoContent();
    }
    [Route("{id:guid}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var coupon = await _couponServices.GetById(id);

        if (coupon == null)
            return NotFound();

        await _couponServices.DeleteCoupon(coupon);

        return Ok(_mapper.Map<CouponDto>(coupon));
    }
}