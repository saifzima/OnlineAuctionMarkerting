namespace OlineAuctionMarketing.Models.Entities
{
	public class ProductBidder : BaseEntities
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int BidderId { get; set; }
		public Bidder Bidder { get; set; }
	}
}
