using Newtonsoft.Json;
using YaCloudKit.MQ;
using YaCloudKit.MQ.Model.Requests;

namespace HotPizzaShop.MessageBus
{
    public class YandexBusMessageBus : IMessageBus
    {
        private string connectionString = "https://message-queue.api.cloud.yandex.net/b1gpgd8h55007ulsuuce/dj600000000jfo8j03hc/HotPizzaShopMes";
        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            var mq = new YandexMqClient("YCAJExvQE0N5OIShIf-BsDhZz", "YCPEjZ-pnbIwTL39d88eqEM7GV7nGIPv4YJKbnGm");

            var sendRequest = new SendMessageRequest()
            {
                QueueUrl = connectionString,
                MessageBody = JsonConvert.SerializeObject(message)
            };
            try
            {
                var sendResponse = await mq.SendMessageAsync(sendRequest);
                Console.WriteLine("Status code: " + sendResponse.HttpStatusCode);
                Console.WriteLine("Message id: " + sendResponse.MessageId);
                Console.WriteLine("MD5: " + sendResponse.MD5OfMessageBody);
            }
            catch (YandexMqServiceException ex)
            {
                Console.WriteLine("Status code: " + ex.StatusCode);
                Console.WriteLine("Request id: " + ex.RequestId);
                Console.WriteLine("Type: " + ex.ErrorType);
                Console.WriteLine("Error code: " + ex.ErrorCode);
                Console.WriteLine("Message: " + ex.Message);
            }

            mq.Dispose();
        }
    }
}
