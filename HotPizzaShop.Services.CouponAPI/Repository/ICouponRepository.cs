using HotPizzaShop.Services.CouponAPI.Models.Dtos;

namespace HotPizzaShop.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task <CouponDto> GetCouponByCode (string couponCode);
    }
}
