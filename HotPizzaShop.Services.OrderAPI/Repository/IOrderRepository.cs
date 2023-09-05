using HotPizzaShop.Services.OrderAPI.Models;

namespace HotPizzaShop.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus (int  orderHeaderId, bool paid);
    }
}
