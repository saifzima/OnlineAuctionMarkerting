using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Models.DTO.Bids
{
    public class BidsDTO : BaseEntities
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }
    }
}
