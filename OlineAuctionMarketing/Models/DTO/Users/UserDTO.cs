using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.DTO.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public string ProfilePicture { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
