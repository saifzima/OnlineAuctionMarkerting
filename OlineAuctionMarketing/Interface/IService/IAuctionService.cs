using OlineAuctionMarketing.Models.DTO.Category;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Product;
using OlineAuctionMarketing.Models.DTO.Bidder;

namespace OlineAuctionMarketing.Interface.IService
{
    public interface IAuctionService
    {
        AuctionResponseModel Create(CreateAuctionRequestModel createProductRequestModel, int userId);
        BaseResponse Update(AuctionUpdateRequestModel productUpdateRequestModel, int auctionId);
        BaseResponse Auction(AuctionRequestModel auctionRequestModel, int userId);
        BaseResponse Delete(int auctionId);
        AuctionResponseModel GetById(int auctionId);
        AuctionResponseModel GetAuctionBidById(int auctionId);
        AuctionsResponseModel GetAll();
        BiddersResponseModel GetAuctionBidder(int auctionId);
        AuctionsResponseModel GetAuctionByCategory(int categoryId);
    }
}
