namespace OlineAuctionMarketing.Models.Entities
{
	public class Bidder : BaseEntities
	{
		public int UsersId { get; set; }
		public Users Users { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public IList<ProductBidder> ProductBidder { get; set; } = new List<ProductBidder>();
	}
}
