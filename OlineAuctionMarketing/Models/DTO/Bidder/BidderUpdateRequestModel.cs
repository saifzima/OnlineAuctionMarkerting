namespace OlineAuctionMarketing.Models.DTO.Bidder
{
    public class BidderUpdateRequestModel : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
