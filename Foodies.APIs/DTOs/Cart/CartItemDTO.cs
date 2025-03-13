using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.Cart
{
    public class CartItemDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Quantity Must be at least 1 and not more than 100")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Unit Price should be greater than Zero!")]
        public decimal UnitPrice { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string vendor { get; set; }
    }
}