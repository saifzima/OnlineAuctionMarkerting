using OlineAuctionMarketing.Models.DTO.Auctioneer;

namespace OlineAuctionMarketing.Models.DTO.Bidder
{
    public class BidderResponseModel :BaseResponse
    {
        public int Id { get; set; }
        public BidderDTO Data { get; set; }
    }
}
