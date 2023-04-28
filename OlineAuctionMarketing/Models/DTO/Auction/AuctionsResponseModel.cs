using OlineAuctionMarketing.Models.DTO.Category;

namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class AuctionsResponseModel : BaseResponse
    {
        public List<AuctionDTO> Data { get; set; } = new List<AuctionDTO>();
    }
}
