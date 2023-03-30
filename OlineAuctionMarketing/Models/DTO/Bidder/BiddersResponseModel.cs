using OlineAuctionMarketing.Models.DTO.Auctioneer;

namespace OlineAuctionMarketing.Models.DTO.Bidder
{
    public class BiddersResponseModel : BaseResponse
    {
        public List<BidderDTO> Data { get; set; } = new List<BidderDTO>();
    }
}
