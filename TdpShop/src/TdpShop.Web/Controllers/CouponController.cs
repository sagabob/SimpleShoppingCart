using Microsoft.AspNetCore.Mvc;
using TdpShop.Web.Models;
using TdpShop.Web.Services;

namespace TdpShop.Web.Controllers;

public class CouponController : Controller
{
    private readonly ICouponServices _couponServices;

    public CouponController(ICouponServices couponServices)
    {
        _couponServices = couponServices;
    }

    public async Task<IActionResult> Index()
    {
        var listOfCoupons = await _couponServices.GetAllCouponsAsync();

        return View(listOfCoupons);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CouponDto model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            model.CouponId = new Guid();
            await _couponServices.CreateCouponsAsync(model);
            TempData["success"] = "Coupon created successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid couponId)
    {
        try
        {
            var couponResponse = await _couponServices.GetCouponByIdAsync(couponId);
            return View(couponResponse);
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        return NotFound();
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid couponId)
    {
        try
        {
            var couponResponse = await _couponServices.GetCouponByIdAsync(couponId);
            return View(couponResponse);
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CouponDto couponDto)
    {
        try
        {
            var isUpdated = await _couponServices.UpdateCouponsAsync(couponDto);

            if (isUpdated)
            {
                TempData["success"] = "Coupon updated successfully";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Fail to update the coupon";
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        return View(couponDto);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CouponDto couponDto)
    {
        try
        {
            await _couponServices.DeleteCouponsAsync(couponDto.CouponId);
            TempData["success"] = "Coupon deleted successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        return View(couponDto);
    }
}