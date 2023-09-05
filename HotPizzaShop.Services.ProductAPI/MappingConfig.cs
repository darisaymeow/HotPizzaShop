using AutoMapper;
using HotPizzaShop.Services.ProductAPI.Models;
using HotPizzaShop.Services.ProductAPI.Models.Dto;

namespace HotPizzaShop.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();

            } );
            return mappingConfig;
        }
    }
}
