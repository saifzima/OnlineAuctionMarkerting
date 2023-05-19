using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.Entities
{
    public class Users : BaseEntities
    {
        public Auctioneer Auctioneer { get; set; }
        public Bidder Bidder { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string phoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
