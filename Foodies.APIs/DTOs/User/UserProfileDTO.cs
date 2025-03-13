namespace Foodies.APIs.DTOs.User
{
    public class UserProfileDTO
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }
}
