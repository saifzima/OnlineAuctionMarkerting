using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class AuctioneerService : IAuctioneerService
    {
        private readonly ApplicationContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IAuctioneerRepository _auctioneerRepository;
        public AuctioneerService(ApplicationContext context, IUserRepository user, IAuctioneerRepository auctioneerRepository)
        {
            _context = context;
            _userRepository = user;
            _auctioneerRepository = auctioneerRepository;
        }
        public AuctioneerResponseModel Create(CreateAuctioneerRequestModel createAuctioneerRequestModel)
        {
            var user = _userRepository.Get(x => x.Email == createAuctioneerRequestModel.Email);
            if (user != null)
            {

                return new AuctioneerResponseModel
                {
                    Massage = "email does not  exist",
                    Status = false
                };
            }
            var userr = new Users
            {
                FirstName = createAuctioneerRequestModel.FirstName,
                LastName = createAuctioneerRequestModel.LastName,
                Email = createAuctioneerRequestModel.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createAuctioneerRequestModel.Password, BCrypt.Net.SaltRevision.Revision2Y),
                phoneNumber = createAuctioneerRequestModel.PhoneNumber,
                Created = DateTime.Now,
                UserName = $"{createAuctioneerRequestModel.FirstName}{new Random().Next(99, 10000)}",
                Role = Enums.UserRole.Auctioneer,
            };
            _userRepository.Create(userr);
            var auctionerr = new Auctioneer
            {
                UsersId = userr.Id,
                Created = DateTime.Now,
            };

            _auctioneerRepository.Create(auctionerr);

            return new AuctioneerResponseModel
            {
                Massage = "Succeccfully created",
                Status = true
            };
        }

        public BaseResponse Delete(int AuctioneerId)
        {
            var getAuctioneer = _auctioneerRepository.Get(x => x.Id == AuctioneerId);
            if (getAuctioneer == null)
            {
                return new BaseResponse
                {
                    Massage = "Auctioneer does not exist",
                    Status = false
                };
            }
            var deleteAuctioneer = _auctioneerRepository.Delete(getAuctioneer);
            return new BaseResponse
            {
                Massage = "Deleted",
                Status = true
            };
        }

        public AuctioneersResponseModel GetAll()
        {
            var get = _auctioneerRepository.GetAllAuctioneers(x => true);
            if (get == null)
            {
                return new AuctioneersResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch",
                };
            }

            return new AuctioneersResponseModel
            {
                Massage = "Successfully fetch",
                Status = true,
                Data = get.Select(x => new AuctioneerDTO
                {
                    Id = x.Id,
                    FirstName = x.Users.FirstName,
                    LastName = x.Users.LastName,
                    Email = x.Users.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(x.Users.Password, BCrypt.Net.SaltRevision.Revision2Y),
                    PhoneNumber = x.Users.phoneNumber,
                    Created = x.Users.Created,

                }).ToList(),
            };
        }

        public AuctioneerResponseModel GetAllAuction(int AuctioneerId)
        {
            throw new NotImplementedException();
        }

        public AuctioneerResponseModel GetById(int AuctioneerId)
        {
            var get = _auctioneerRepository.Get(x => x.Id == AuctioneerId);
            if (get == null)
            {
                return new AuctioneerResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch"
                };
            }
            var auctioneer = new AuctioneerDTO
            {
                Id = get.Id,
                FirstName = get.Users.FirstName,
                LastName = get.Users.LastName,
                Email = get.Users.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(get.Users.Password, BCrypt.Net.SaltRevision.Revision2Y),
                PhoneNumber = get.Users.phoneNumber,
                Created = get.Users.Created,
            };
            return new AuctioneerResponseModel
            {
                Data = auctioneer,
                Massage = "Successfully fetch",
                Status = true
            };
        }

        public BaseResponse Update(AuctioneerResponseModel auctioneerUpdateRequestModel, int AuctioneerId)
        {
            var get = _auctioneerRepository.Get(x => x.Id ==
            AuctioneerId);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "Successfully updated",
                    Status = true
                };
            }
            get.Users.FirstName = auctioneerUpdateRequestModel.Data.FirstName ?? get.Users.FirstName;
            get.Users.LastName = auctioneerUpdateRequestModel.Data.LastName ?? get.Users.LastName;
            if (auctioneerUpdateRequestModel.Data.Password != null)
            {
                get.Users.Password = BCrypt.Net.BCrypt.HashPassword(auctioneerUpdateRequestModel.Data.Password, BCrypt.Net.SaltRevision.Revision2Y);
            }
            _userRepository.UpdateRole(get.Users);
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }

    }
}
