using Microsoft.AspNetCore.Mvc;
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
}