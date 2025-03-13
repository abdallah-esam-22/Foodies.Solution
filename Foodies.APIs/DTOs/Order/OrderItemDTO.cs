using Foodies.Core.Entities.Order_Aggregate;

namespace Foodies.APIs.DTOs.Order
{
    public class OrderItemDTO
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string PictureUrl { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
