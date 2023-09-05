using HotPizzaShop.Web.Models;

namespace HotPizzaShop.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<T> GetCoupon<T>(string couponCode, string token = null);

    }
}
