using HotPizzaShop.Services.CouponAPI.Models.Dtos;
using HotPizzaShop.Services.CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotPizzaShop.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponAPIController : Controller
    {

        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;

        public CouponAPIController(ICouponRepository cartRepository)
        {
            this._couponRepository = cartRepository;
            this._response = new ResponseDto();
        }
        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccesed = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
