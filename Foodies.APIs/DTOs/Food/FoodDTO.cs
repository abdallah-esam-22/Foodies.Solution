using Foodies.Core.Entities;

namespace Foodies.APIs.DTOs.Food
{
    public class FoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
        public string Category { get; set; }

        public int VendorId { get; set; }
        public string Vendor { get; set; }
    }
}
