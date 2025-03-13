namespace Foodies.Core.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public string Category { get; set; }
        public string vendor { get; set; }
    }
}