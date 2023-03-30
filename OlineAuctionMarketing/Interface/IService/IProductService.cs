using OlineAuctionMarketing.Models.DTO.Category;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Product;

namespace OlineAuctionMarketing.Interface.IService
{
    public interface IProductService
    {
        ProductResponseModel Create(CreateProductRequestModel createProductRequestModel, int userId);
        BaseResponse Update(ProductUpdateRequestModel productUpdateRequestModel, int productId);
        BaseResponse Delete(int productId);
        ProductResponseModel GetById(int productId);
        ProductsResponseModel GetAll();
    }
}
