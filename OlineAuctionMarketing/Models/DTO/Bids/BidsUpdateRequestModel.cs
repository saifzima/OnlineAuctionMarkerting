using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.DTO.Bids
{
    public class BidsUpdateRequestModel
    {
        public string Image { get; set; }
        public string ProductName { get; set; }
        public Condition ItemCondition { get; set; }
        public DateTime TimeLeft { get; set; }
        public DateTime AuctionEndsTime { get; set; }
        public double Price { get; set; }
        public int NumberOfBidder { get; set; }
    }
}
