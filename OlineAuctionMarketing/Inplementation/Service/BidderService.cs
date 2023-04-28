using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models.DTO.Bidder;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class BidderService : IBidderService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuctioneerRepository _auctioneerRepository;
        private readonly IBidderRepository _bidderRepository;
        public BidderService(IUserRepository user, IAuctioneerRepository auctioneerRepository, IBidderRepository bidderRepository)
        {
            _userRepository = user;
            _auctioneerRepository = auctioneerRepository;
            _bidderRepository = bidderRepository;
        }

        public BidderResponseModel Create(CreateBidsRequestModel createBidderRequestModel)
        {
            var user = _userRepository.Get(x => x.Email == createBidderRequestModel.Email);
            if (user != null)
            {

                return new BidderResponseModel
                {
                    Massage = "email does not  exist",
                    Status = false
                };
            }
            var userr = new Users
            {
                FirstName = createBidderRequestModel.FirstName,
                LastName = createBidderRequestModel.LastName,
                Email = createBidderRequestModel.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createBidderRequestModel.Password, BCrypt.Net.SaltRevision.Revision2Y),
                phoneNumber = createBidderRequestModel.PhoneNumber,
                Created = DateTime.Now,
                Role = Enums.UserRole.Auctioneer,
            };
            _userRepository.Create(userr);
            var bidderr = new Bidder
            {
                UsersId = userr.Id,
                Address = createBidderRequestModel.Address,
                City= createBidderRequestModel.City,
                Created = DateTime.Now,

            };

            _bidderRepository.Create(bidderr);

            return new BidderResponseModel
            {
                Massage = "Succeccfully created",
                Status = true
            };
        }

        public BaseResponse Delete(int BidderId)
        {
            var getBidder = _bidderRepository.Get(x => x.Id == BidderId);
            if (getBidder == null)
            {
                return new BaseResponse
                {
                    Massage = "Auctioneer does not exist",
                    Status = false
                };
            }
            var deleteBidder = _bidderRepository.Delete(getBidder);
            /*            _userRepository.Delete(getAuctioneer.Users);
            */
            return new BaseResponse
            {
                Massage = "Deleted",
                Status = true
            };
        }

        public BiddersResponseModel GetAll()
        {
            var get = _bidderRepository.GetAllBidders(x => true);
            if (get == null)
            {
                return new BiddersResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch",
                };
            }

            return new BiddersResponseModel
            {
                Massage = "Successfully fetch",
                Status = true,
                Data = get.Select(x => new BidderDTO
                {
                    Id = x.Id,
                    FirstName = x.Users.FirstName,
                    LastName = x.Users.LastName,
                    Password = BCrypt.Net.BCrypt.HashPassword(x.Users.Password, BCrypt.Net.SaltRevision.Revision2Y),
                    PhoneNumber = x.Users.phoneNumber,
                    Address = x.Address,
                    City = x.City,
                    Created = x.Users.Created,

                }).ToList(),
            };
        }

        public BidderResponseModel GetById(int BidderId)
        {
            var get = _bidderRepository.Get(x => x.Id == BidderId);
            if (get == null)
            {
                return new BidderResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch"
                };
            }
            var bidder = new BidderDTO
            {
                Id = get.Id,
                FirstName = get.Users.FirstName,
                LastName = get.Users.LastName,
                Email = get.Users.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(get.Users.Password, BCrypt.Net.SaltRevision.Revision2Y),
                PhoneNumber = get.Users.phoneNumber,
                Address = get.Address,
                City = get.City,
                Created = get.Users.Created,
            };
            return new BidderResponseModel
            {
                Data = bidder,
                Massage = "Successfully fetch",
                Status = true
            };
        }

        public BaseResponse Update(BidderResponseModel bidderUpdateRequestModel, int bidderId)
        {
            var get = _bidderRepository.Get(x => x.Id ==
                        bidderId);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "Successfully updated",
                    Status = true
                };
            }
            get.Users.FirstName = bidderUpdateRequestModel.Data.FirstName;
            get.Users.LastName = bidderUpdateRequestModel.Data.LastName;
            get.Users.Password = BCrypt.Net.BCrypt.HashPassword(bidderUpdateRequestModel.Data.Password, BCrypt.Net.SaltRevision.Revision2Y);

            _userRepository.UpdateRole(get.Users);
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }
    }
}
