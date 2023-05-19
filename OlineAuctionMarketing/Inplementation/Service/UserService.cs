using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Users;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public CreateUserRequestModel Create(CreateUserRequestModel createrUserRequestModel)
        {
            var users = new Users
            {
                Password = BCrypt.Net.BCrypt.HashPassword(createrUserRequestModel.Password),
                Email = createrUserRequestModel.Email,
                Role = createrUserRequestModel.Role,
                Created = DateTime.Now,
            };
            _userRepository.Create(users);
            return createrUserRequestModel;
        }

        public BaseResponse Delete(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
            return new BaseResponse
            {
                Massage = "it deleted successfully",
                Status = true
            };
        }

        public UserResponseModel GetById(int id)
        {
            var get = _userRepository.GetById(id);
            if (get == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Massage = "Successfully fetch",
                };
            }
            return new UserResponseModel
            {
                Data = new UserDTO
                {
                    Id = id,
                    Email = get.Email,
                    FirstName = get.FirstName,
                    LastName = get.LastName,
                    PhoneNumber = get.phoneNumber,
                },
                Massage = "Successfully get",
                Status = true
            };
        }

        public UserResponseModel Login(UserLoginRequestModel userLoginRequestModel)
        {
            var user = _userRepository.GetByEmail(userLoginRequestModel.Email);
            if (user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Massage = "Invalid credentials"
                };
            }
            var verified = BCrypt.Net.BCrypt.Verify(userLoginRequestModel.Password, user.Password);
            if (verified)
            {
                return new UserResponseModel
                {
                    Status = true,
                    Data = new UserDTO
                    {
                        Id = user.Id,
                        Email = userLoginRequestModel.Email,
                        Role = user.Role,
                    },
                    Massage = "Successfully logged in"
                };
            }
            return new UserResponseModel
            {
                Status = false,
                Massage = "Invalid credentials"
            };
        }

        public UserRoleUpdateRequestModel UpdateRole(UserRoleUpdateRequestModel updateUserPasswordRequestModel)
        {
            var user = _userRepository.GetByEmail(updateUserPasswordRequestModel.Email);
            _userRepository.UpdateRole(user);
            return new UserRoleUpdateRequestModel
            {
                Massage = "it deleted successfully",
                Status = true
            };
        }

        public BaseResponse Update(UserResponseModel userResponseModel, int userId)
        {
            var get = _userRepository.Get(x => x.Id == userId);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "not updated",
                    Status = false
                };
            }
            get.FirstName = userResponseModel.Data.FirstName ?? get.FirstName;
            get.LastName = userResponseModel.Data.LastName ?? get.LastName;
            get.UserName = userResponseModel.Data.UserName ?? get.UserName;
            get.Role = get.Role;
            if (userResponseModel.Data.Password != null)
            {
                get.Password = BCrypt.Net.BCrypt.HashPassword(userResponseModel.Data.Password, BCrypt.Net.SaltRevision.Revision2Y);
            }
            _userRepository.UpdateRole(get);
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }
    }
}
