using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Foodies.APIs.DTOs.User
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$"
        //    , ErrorMessage = "the password should have a min length of 8" +
        //    " and should contain at least one uppercase and one lowecase and one special charachter and one digit")]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
