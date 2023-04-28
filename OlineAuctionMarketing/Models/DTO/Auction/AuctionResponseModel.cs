namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class AuctionResponseModel : BaseResponse
    {
        public int Id { get; set; }
        public AuctionDTO Data { get; set; }
    }
}
