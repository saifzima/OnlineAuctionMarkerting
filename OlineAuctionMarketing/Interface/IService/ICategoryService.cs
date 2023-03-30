using OlineAuctionMarketing.Models.DTO.Bidder;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Category;

namespace OlineAuctionMarketing.Interface.IService
{
    public interface ICategoryService
    {
        CategoryResponseModel Create(CreateCategoryRequestModel createCategoryRequestModel);
        BaseResponse Update(CategoryResponseModel categoryUpdateRequestModel, int categoryId);
        BaseResponse Delete(int categoryId);
        CategoryResponseModel GetById(int categoryId);
        CategorysResponseModel GetAll();
    }
}
