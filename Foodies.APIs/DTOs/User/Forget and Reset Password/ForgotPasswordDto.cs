using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.User
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
