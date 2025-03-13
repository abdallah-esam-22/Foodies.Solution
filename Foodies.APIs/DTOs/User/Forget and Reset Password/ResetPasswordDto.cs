using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.User
{
    public class ResetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
