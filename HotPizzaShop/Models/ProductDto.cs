using System.ComponentModel.DataAnnotations;

namespace HotPizzaShop.Web.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
            Count = 1;
        }
        public int ProductId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        [Range(1, 100)]
        public int Count { get; set; }
    }
}
