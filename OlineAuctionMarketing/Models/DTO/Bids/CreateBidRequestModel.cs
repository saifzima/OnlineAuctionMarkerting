namespace OlineAuctionMarketing.Models.DTO.Bids
{
    public class CreateBidRequestModel
    {
        public int AuctionId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }
    }
}
  