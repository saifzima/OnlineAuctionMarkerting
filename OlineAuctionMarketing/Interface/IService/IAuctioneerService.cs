using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models;

namespace OlineAuctionMarketing.Interface.IService
{
	public interface IAuctioneerService
	{
		AuctioneerResponseModel Create(CreateAuctioneerRequestModel createAuctioneerRequestModel);
		BaseResponse Update(AuctioneerResponseModel auctioneerUpdateRequestModel, int AuctioneerId);
		BaseResponse Delete(int AuctioneerId);
		AuctioneerResponseModel GetById(int AuctioneerId);
		//AuctioneerResponseModel GetByEmail(string Email);
		AuctioneersResponseModel GetAll();
	}
}
