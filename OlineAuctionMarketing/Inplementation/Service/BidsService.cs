using OlineAuctionMarketing.Inplementation.Repository;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO;
using OlineAuctionMarketing.Models.DTO.AuctionBidder;
using OlineAuctionMarketing.Models.DTO.Bidder;
using OlineAuctionMarketing.Models.DTO.Bids;
using OlineAuctionMarketing.Models.DTO.Category;
using OlineAuctionMarketing.Models.Entities;
using System.Security.Claims;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class BidsService : IBidsService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidsRepository _bidsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BidsService(IBidsRepository bidsRepository, IAuctionRepository auctionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _bidsRepository = bidsRepository;
            _auctionRepository = auctionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public BidResponseModel Create(CreateBidRequestModel createBidRequestModel)
        {
            var bid = _bidsRepository.Get(x => x.Time == createBidRequestModel.Time);
            if (bid != null)
            {

                return new BidResponseModel
                {
                    Massage = "Name does not  exist",
                    Status = false
                };
            }
            var bids = new Bids
            {
                BidderId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                AuctionId = createBidRequestModel.AuctionId,
                Price= createBidRequestModel.Price,
                Time= createBidRequestModel.Time,
                Quantity= createBidRequestModel.Quantity,
                Created = DateTime.Now,
            };
            _bidsRepository.Create(bids);
            return new BidResponseModel
            {
                Massage = "Succeccfully created",
                Status = true
            };
        }

        public BaseResponse Delete(int bidId)
        {
            var getBid = _bidsRepository.Get(x => x.Id == bidId);
            if (getBid == null)
            {
                return new BaseResponse
                {
                    Massage = "Bids does not exist",
                    Status = false
                };
            }
            var deleteBids = _bidsRepository.Delete(getBid);
            return new BaseResponse
            {
                Massage = "Deleted",
                Status = true
            };
        }

        public BidsResponseModel GetAll()
        {
            var get = _bidsRepository.GetAllBids(x => true);
            if (get == null)
            {
                return new BidsResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch",
                };
            }

            return new BidsResponseModel
            {
                Massage = "Successfully fetch",
                Status = true,
                Data = get.Select(x => new BidsDTO
                {
                    Id = x.Id,
                    Price= x.Price,
                    Quantity= x.Quantity,
                    Time= x.Time,
                    Created = x.Created,

                }).ToList(),
            };
        }
        public AuctionBiddersResponseModel GetAllBids(int auctionId)
        {
            //var getAll = _auctionRepository.GetAuctionBidder(auctionId).ToList();
            var getAll = _bidsRepository.GetAllBids(x => x.AuctionId == auctionId);
            
            if (getAll == null)
            {
                return new AuctionBiddersResponseModel
                {
                    Massage = "failed to auction",
                    Status = false,
                };
            }

            var auctioBidder = new AuctionBiddersResponseModel
            {
                Massage = "successful",
                Status = true,
                Data = getAll.Select(x => new ActionBidderDTO
                {
                    Id = x.Id,
                    FirstName =x.Bidder.Users.FirstName,
                    Price=x.Auction.StartingPrice,

                }).ToList(),
            };
            return auctioBidder;
        }

        public BidResponseModel GetById(int bidId)
        {
            var get = _bidsRepository.Get(x => x.Id == bidId);
            if (get == null)
            {
                return new BidResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch"
                };
            }
            var bid = new BidsDTO
            {
                Id = get.Id,
                Price = get.Price,
                Quantity= get.Quantity,
                Time= get.Time,
                IsDeleted = get.IsDeleted,
                Modified = get.Modified,
                Created = get.Created,
            };
            return new BidResponseModel
            {
                Data = bid,
                Massage = "Successfully fetch",
                Status = true
            };
        }

        public BaseResponse Update(BidResponseModel bidUpdateRequestModel, int bidId)
        {
            var get = _bidsRepository.Get(x => x.Id == bidId);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "Successfully updated",
                    Status = true
                };
            }
            get.Id = bidId;
            get.Price = bidUpdateRequestModel.Data.Price;
            get.Quantity = bidUpdateRequestModel.Data.Quantity;
            get.Time = bidUpdateRequestModel.Data.Time;
            _bidsRepository.Update(get);
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }
    }
}
