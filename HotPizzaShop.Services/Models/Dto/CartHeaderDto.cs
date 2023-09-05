using System.ComponentModel.DataAnnotations;

namespace HotPizzaShop.Services.ShoppingCartAPI.Models.Dto
{
    public class CartHeaderDto
    {
        public int CartHeaderId { get; set; }

        public string UserId { get; set; }

        public string? CouponCode { get; set; }
    }
}
