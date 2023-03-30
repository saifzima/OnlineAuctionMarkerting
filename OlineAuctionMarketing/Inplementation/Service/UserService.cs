using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Users;
using OlineAuctionMarketing.Models.Entities;
using OlineAuctionMarketing.Models;

namespace OlineAuctionMarketing.Inplementation.Service
{
	public class UserService :IUserService
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
				Massage = "Successfully get",
				Status = true
			};
		}

		public UserResponseModel Login(UserLoginRequestModel userLoginRequestModel)
		{
			var user = _userRepository.GetByEmail(userLoginRequestModel.Email);
			if(user == null)
			{
                return new UserResponseModel
                {
                    Status = false,
                    Massage = "Invalid credentials"
                };
            }
			var verified = BCrypt.Net.BCrypt.Verify(userLoginRequestModel.Password,user.Password);
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
	}
}
