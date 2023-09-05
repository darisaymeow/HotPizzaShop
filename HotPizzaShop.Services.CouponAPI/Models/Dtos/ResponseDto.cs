namespace HotPizzaShop.Services.CouponAPI.Models.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccesed { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = " ";
        public List<string> ErrorMessage { get; set; }

    }
}
