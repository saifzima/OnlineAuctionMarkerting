namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class ProductResponseModel : BaseResponse
    {
        public int Id { get; set; }
        public ProductDTO Data { get; set; }
    }
}
