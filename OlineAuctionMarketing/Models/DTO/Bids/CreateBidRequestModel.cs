using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.DTO.Bids
{
    public class CreateBidRequestModel
    {
        public int AuctionId { get; set; }
        public double Price { get; set; }
    }
}
  