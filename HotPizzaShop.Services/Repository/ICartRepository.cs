using HotPizzaShop.Services.ShoppingCartAPI.Models.Dto;

namespace HotPizzaShop.Services.ShoppingCartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId (string userId);
        Task<CartDto> CreateUpdateCart(CartDto cart);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RomoveCoupon(string userId);
        Task<bool> ClearCart(string userId);

    }
}
