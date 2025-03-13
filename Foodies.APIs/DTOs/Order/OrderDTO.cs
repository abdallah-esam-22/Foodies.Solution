using Foodies.APIs.DTOs.User;
using Foodies.Core.Entities.Order_Aggregate;
using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.Order
{
    public class OrderDTO
    {
        [Required]
        public string CartId { get; set; }

        [Required]
        public int DeliveryMethodId { get; set; }

        [Required]
        public AddressDTO Address { get; set; }
    }
}
