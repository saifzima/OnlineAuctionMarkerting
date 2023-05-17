using OlineAuctionMarketing.Models.DTO.Bidder;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Bids;
using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;
using OlineAuctionMarketing.Models.DTO.AuctionBidder;

namespace OlineAuctionMarketing.Interface.IService
{
    public interface IBidsService
    {
        BidResponseModel Create(CreateBidRequestModel createBidRequestModel);
        BaseResponse Update(BidResponseModel bidUpdateRequestModel, int bidId);
        BaseResponse Delete(int bidId);
        BidResponseModel GetById(int bidId);
        BidsResponseModel GetAll();
        AuctionBiddersResponseModel GetAllAuctionBidders(int auctionId);

    }
}
