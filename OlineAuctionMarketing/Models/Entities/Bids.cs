using OlineAuctionMarketing.Models.DTO.Bids;

namespace OlineAuctionMarketing.Models.Entities
{
    public class Bids : BaseEntities
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public int BidderId { get; set; }
        public Bidder Bidder { get; set; }

    }
}
