namespace Foodies.Core.Entities.Order_Aggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }
        public OrderItem(OrderItemFood foodItem, decimal unitPrice, int quantity)
        {
            FoodItem = foodItem;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public OrderItemFood FoodItem { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}