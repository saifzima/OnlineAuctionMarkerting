using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.AuctionBidder;
using OlineAuctionMarketing.Models.DTO.Bids;
using OlineAuctionMarketing.Models.Entities;
using System.Security.Claims;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class BidsService : IBidsService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidsRepository _bidsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuctionBidderRepository _auctionBidderRepository;
        private readonly IBidderRepository _bidderRepository;
        public BidsService(IBidsRepository bidsRepository, IAuctionRepository auctionRepository, IHttpContextAccessor httpContextAccessor, IAuctionBidderRepository auctionBidderRepository, IBidderRepository bidderRepository)
        {
            _bidsRepository = bidsRepository;
            _auctionRepository = auctionRepository;
            _httpContextAccessor = httpContextAccessor;
            _auctionBidderRepository = auctionBidderRepository;
            _bidderRepository = bidderRepository;
        }

        public BidResponseModel Create(CreateBidRequestModel model)
        {
            var highestBid = 0.0;
            var auctionBid = _bidsRepository.Get(x => x.AuctionId == model.AuctionId);
            if (auctionBid != null)
            {
                highestBid = _bidsRepository.GetHighestBids(x => x.AuctionId == model.AuctionId);
            }
            if (model.Price <= highestBid)
            {
                return new BidResponseModel
                {
                    Massage = $"You can't bid lower than {highestBid} per product",
                    Status = false
                };
            }
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var bidder = _bidderRepository.Get(x => x.UsersId == userId);
            var auctioBidder = new AuctionBidder
            {
                AuctionId = model.AuctionId,
                BidderId = bidder.Id,
                Created = DateTime.Now,
            };
            var bids = new Bids
            {
                BidderId = bidder.Id,
                AuctionId = model.AuctionId,
                Price = model.Price,
                Created = DateTime.Now,
            };
            _bidsRepository.Create(bids);
            _auctionBidderRepository.Create(auctioBidder);
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
            var get = _bidsRepository.GetAllAuctionBidders(x => true);
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
                    Price = x.Price,
                    FirstName = x.Bidder.Users.FirstName,

                    Created = x.Created,

                }).ToList(),
            };
        }
        public AuctionBiddersResponseModel GetAllAuctionBidders(int auctionId)
        {
            var getAll = _bidsRepository.GetAllAuctionBidders(x => x.AuctionId == auctionId);

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
                    FirstName = x.Bidder.Users.FirstName,
                    Price = x.Price,
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
            _bidsRepository.Update(get);
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }

        //public BidResponseModel GetBidByAuctionId(int auctionId)
        //{
        //    var get = _bidsRepository.GetAllAuctionBids(x => x.AuctionId == auctionId);
        //    if (get == null)
        //    {
        //        return new BidResponseModel
        //        {
        //            Status = false,
        //            Massage = "Failed to fetch"
        //        };
        //    }
        //    var bidsResponseModel = new BidResponseModel
        //    {
        //        Massage = "successful",
        //        Status = true,
        //        Data = get.Select(x => new BidsDTO
        //        {
        //            Id = x.Id,
        //            Price = x.Auction.StartingPrice,
        //            AuctionEndsTime = x.Auction.EndingTime,
        //            Image = x.Auction.Image,
        //            ProductName = x.Auction.ProductName,

        //        }).ToList(),

        //    };
        //    var bid = new BidsDTO
        //    {
        //        Id = get.Id,
        //        Price = get.Price,
        //        IsDeleted = get.IsDeleted,
        //        Modified = get.Modified,
        //        Created = get.Created,
        //    };
        //    return new BidResponseModel
        //    {
        //        Data = bid,
        //        Massage = "Successfully fetch",
        //        Status = true
        //    };
        //}


    }
}
