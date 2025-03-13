using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.User
{
    public class VerifyCodeDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
