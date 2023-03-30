namespace OlineAuctionMarketing.Models.DTO.Category
{
    public class CategoryResponseModel : BaseResponse
    {
        public int Id { get; set; }
        public CategoryDTO Data { get; set; }
    }
}
