using OlineAuctionMarketing.Models.DTO.Auctioneer;

namespace OlineAuctionMarketing.Models.DTO.AuctionBidder;

public class AuctionBiddersResponseModel:BaseResponse
{
    public List<ActionBidderDTO> Data { get; set; } = new List<ActionBidderDTO>();
}
