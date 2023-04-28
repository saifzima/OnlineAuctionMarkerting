namespace OlineAuctionMarketing.Models.Entities
{
	public class AuctionBidder : BaseEntities
	{
		public int AuctionId { get; set; }
		public Auction Auction { get; set; }

		public int BidderId { get; set; }
		public Bidder Bidder { get; set; }
	}
}
