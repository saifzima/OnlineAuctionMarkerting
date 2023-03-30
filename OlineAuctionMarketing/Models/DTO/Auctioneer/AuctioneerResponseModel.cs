using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Models.DTO.Auctioneer
{
	public class AuctioneerResponseModel : BaseResponse
	{
		public int Id { get; set; }
		public AuctioneerDTO Data { get; set; }
	}
}
