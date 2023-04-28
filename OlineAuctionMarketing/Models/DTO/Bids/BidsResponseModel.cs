using OlineAuctionMarketing.Models.DTO.Bidder;

namespace OlineAuctionMarketing.Models.DTO.Bids
{
    public class BidsResponseModel : BaseResponse
    {
        public List<BidsDTO> Data { get; set; } = new List<BidsDTO>();
    }
}
