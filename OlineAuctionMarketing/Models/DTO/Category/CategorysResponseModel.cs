using OlineAuctionMarketing.Models.DTO.Auctioneer;

namespace OlineAuctionMarketing.Models.DTO.Category
{
    public class CategorysResponseModel : BaseResponse
    {
        public List<CategoryDTO> Data { get; set; } = new List<CategoryDTO>();

    }
}
