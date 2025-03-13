using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.Cart
{
    public class CartDTO
    {
        [Required]
        public string Id { get; set; }
        public List<CartItemDTO> Items { get; set; }
    }
}
