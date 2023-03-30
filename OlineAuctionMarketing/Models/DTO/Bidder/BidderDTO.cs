using OlineAuctionMarketing.Enums;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Models.DTO.Bidder
{
    public class BidderDTO : BaseEntities
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public UserRole role { get; set; }
    }
}
