using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Models.DTO.Auctioneer
{
	public class AuctioneersResponseModel : BaseResponse
	{
		public List<AuctioneerDTO> Data { get; set; } = new List<AuctioneerDTO>();
	}
}
