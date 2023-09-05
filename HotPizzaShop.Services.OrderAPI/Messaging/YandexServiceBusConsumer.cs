using HotPizzaShop.Services.OrderAPI.Messages;
using HotPizzaShop.Services.OrderAPI.Models;
using HotPizzaShop.Services.OrderAPI.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using YaCloudKit.MQ;
using YaCloudKit.MQ.Marshallers;
using YaCloudKit.MQ.Model;
using YaCloudKit.MQ.Model.Requests;
using YaCloudKit.MQ.Model.Responses;

namespace HotPizzaShop.Services.OrderAPI.Messaging

{
    public class YandexServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string subcriptionName;
        private readonly string checkoutMessageTopic;

        private readonly OrderRepository _orderRepository;

        private readonly IConfiguration _configuration;

        public YandexServiceBusConsumer(OrderRepository orderRepository, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            subcriptionName = _configuration.GetValue<string>("SubcribtionName");
            checkoutMessageTopic = _configuration.GetValue<string>("CheckoutMessageTopic");

            var mq = new YandexMqClient("YCAJExvQE0N5OIShIf-BsDhZz", "YCPEjZ-pnbIwTL39d88eqEM7GV7nGIPv4YJKbnGm");
        }
        private async Task OnCheckOutMessageReceived(ReceiveMessageResponse args)
        {
           

            var messages = args.Messages;
            foreach (var mess in messages)
            {

            var body = mess.Body;
            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

            OrderHeader orderHeader = new()
            {
                UserId = checkoutHeaderDto.UserId,
                FirstName = checkoutHeaderDto.FirstName,
                LastName = checkoutHeaderDto.LastName,
                OrderDetails = new List<OrderDetails>(),
                CardNumber = checkoutHeaderDto.CardNumber,
                CouponCode = checkoutHeaderDto.CouponCode,
                CVV = checkoutHeaderDto.CVV,
                DiscountTotal = checkoutHeaderDto.DiscountTotal,
                Email = checkoutHeaderDto.Email,
                ExpityMonthYear = checkoutHeaderDto.ExpityMonthYear,
                OrderTime = DateTime.Now,
                OrderTotal = checkoutHeaderDto.OrderTotal,
                PaymentStatus = false,
                Phone = checkoutHeaderDto.Phone,
                PickupDateTime = DateTime.Now
            };
                foreach (var detailList in checkoutHeaderDto.CartDetails)
                {
                    OrderDetails orderDetails = new()
                    {
                        ProductId = detailList.ProductId,
                        ProductName = detailList.Product.Name,
                        Price = detailList.Product.Price,
                        Count = detailList.Count
                    };
                    orderHeader.CartTotalItems += detailList.Count;
                    orderHeader.OrderDetails.Add(orderDetails);
                }

                await _orderRepository.AddOrder(orderHeader);
            }

        }
    }
}
