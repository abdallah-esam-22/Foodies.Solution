using AutoMapper;
using Foodies.APIs.DTOs.Order;
using Foodies.Core.Entities.Order_Aggregate;

namespace Foodies.APIs.Helpers
{
    public class OrderItemPicURLResolver : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration configuration;

        public OrderItemPicURLResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (source.FoodItem.PictureUrl is not null)
                return $"{configuration["Host"]}/{source.FoodItem.PictureUrl}";

            return string.Empty;
        }
    }
}
