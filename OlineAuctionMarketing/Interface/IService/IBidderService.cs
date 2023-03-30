using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Bidder;

namespace OlineAuctionMarketing.Interface.IService
{
    public interface IBidderService
    {
        BidderResponseModel Create(CreateBidderRequestModel createBidderRequestModel);
        BaseResponse Update(BidderResponseModel bidderUpdateRequestModel, int bidderId);
        BaseResponse Delete(int BidderId);
        BidderResponseModel GetById(int BidderId);
        BiddersResponseModel GetAll();
    }
}
