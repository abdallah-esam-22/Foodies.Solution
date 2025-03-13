using Foodies.Core.Entities.Order_Aggregate;

namespace Foodies.APIs.DTOs.Order
{
    public class OrdersToReturnDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public string DeliveryMethod { get; set; }
        public decimal Total { get; set; }
    }
}
