using OlineAuctionMarketing.Models.DTO.Users;
using OlineAuctionMarketing.Models;

namespace OlineAuctionMarketing.Interface.IService
{
	public interface IUserService
	{
		CreateUserRequestModel Create(CreateUserRequestModel createrUserRequestModel);
		UserResponseModel Login(UserLoginRequestModel userLoginRequestModel);
		BaseResponse Delete(int id);
		UserResponseModel GetById(int id);
		UserRoleUpdateRequestModel UpdateRole(UserRoleUpdateRequestModel updateUserPasswordRequestModel);
	}
}
