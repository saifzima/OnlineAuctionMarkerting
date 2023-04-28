namespace OlineAuctionMarketing.Models.DTO.Bids
{
    public class BidsUpdateRequestModel
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }
    }
}
