using Foodies.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Entities.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(string buyerEmail, decimal subTotal, DeliveryMethod? deliveryMethod, Address address, ICollection<OrderItem> orderItems)
        {
            BuyerEmail = buyerEmail;
            SubTotal = subTotal;
            DeliveryMethod = deliveryMethod;
            Address = address;
            OrderItems = orderItems;
        }

        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal SubTotal { get; set; }


        public DeliveryMethod? DeliveryMethod { get; set; }

        public Address Address { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Cost;
        }
    }
}
