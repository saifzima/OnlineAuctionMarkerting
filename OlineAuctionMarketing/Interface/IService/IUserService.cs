using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Users;

namespace OlineAuctionMarketing.Interface.IService
{
    public interface IUserService
    {
        CreateUserRequestModel Create(CreateUserRequestModel createrUserRequestModel);
        UserResponseModel Login(UserLoginRequestModel userLoginRequestModel);
        BaseResponse Delete(int id);
        BaseResponse Update(UserResponseModel userResponseModel, int userId);
        UserResponseModel GetById(int id);
        UserRoleUpdateRequestModel UpdateRole(UserRoleUpdateRequestModel updateUserPasswordRequestModel);
    }
}
