namespace HotPizzaShop.Services.ProductAPI
{
    public static class SD
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static string ProductAPIBase {get; set;}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public enum ApiType 
        {
            GET,
            POST,
            PUT,
            DELETE
        }

    }
}
