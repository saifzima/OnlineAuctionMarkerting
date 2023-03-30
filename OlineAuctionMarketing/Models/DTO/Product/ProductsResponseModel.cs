using OlineAuctionMarketing.Models.DTO.Category;

namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class ProductsResponseModel : BaseResponse
    {
        public List<ProductDTO> Data { get; set; } = new List<ProductDTO>();
    }
}
