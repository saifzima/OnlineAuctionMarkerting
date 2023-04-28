namespace OlineAuctionMarketing.Models.Entities
{
	public class Bidder : BaseEntities
	{
		public int UsersId { get; set; }
		public Users Users { get; set; }
		public double Amount { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public IList<AuctionBidder> AuctionBidder { get; set; } = new List<AuctionBidder>();
        public IList<Bids> Bids { get; set; } = new List<Bids>();

    }
}
