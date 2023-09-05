using System.ComponentModel.DataAnnotations;

namespace HotPizzaShop.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }

        public string UserId { get; set; }

        public string? CouponCode { get; set; }
    }
}
