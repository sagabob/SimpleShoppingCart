using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TdpShop.Services.CouponApi.Data;
using TdpShop.Services.CouponApi.Models.Dto;

namespace TdpShop.Services.CouponApi.Services;

public class CouponServices: ICouponServices
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public CouponServices(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<CouponDto>> GetAllCouponDtos()
    {
        var allCoupons = await _db.Coupons.ToListAsync();
        return _mapper.Map<List<CouponDto>>(allCoupons);
    }
}