
using HotPizzaShop.Web.Models;
using HotPizzaShop.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HotPizzaShop.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }


        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("HotPizzaShopAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,"application/json");
                }

                if(!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                HttpResponseMessage apiResponse = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default :
                        message.Method = HttpMethod.Get;
                        break;

                }

                var ChickReq = apiRequest.Data;
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
#pragma warning disable CS8603 // Possible null reference return.
                return apiResponseDto;
#pragma warning restore CS8603 // Possible null reference return.
     
            }

             catch (Exception e)
            {

                   var dto = new ResponseDto
                   {
                        DisplayMessage = "Error",
                        ErrorMessage = new List<string> { Convert.ToString(e.Message) },
                        IsSuccesed = false,
                   };

                   var res = JsonConvert.SerializeObject(dto);
                   var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
#pragma warning disable CS8603 // Possible null reference return.
                   return apiResponseDto;
#pragma warning restore CS8603 // Possible null reference return.

            }

        }

            public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
