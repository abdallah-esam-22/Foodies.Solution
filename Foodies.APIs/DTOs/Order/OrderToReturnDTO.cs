using Foodies.Core.Entities.Order_Aggregate;

namespace Foodies.APIs.DTOs.Order
{
    public class OrderToReturnDTO
    {
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public string DeliveryMethod { get; set; }
        public decimal DeliveryMethodCost { get; set; }

        public Address Address { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
