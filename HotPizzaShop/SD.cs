namespace HotPizzaShop.Web
{
    public static class SD
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static string ProductAPIBase {get; set;}
        public static string ShoppingCartAPIBase { get; set; }
        public static string CouponAPIBase { get; set; }

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
