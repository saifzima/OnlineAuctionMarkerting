namespace OlineAuctionMarketing.Models.Entities
{
	public class Product :BaseEntities
	{
		public string Image { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public DateTime StartingTime { get; set; }
		public DateTime EndingTime { get; set; } = DateTime.MinValue;
		public double StartingPrice { get; set; }
		public int AuctioneerId { get; set; }
		public Auctioneer Auctioneer { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public IList<ProductBidder> Bidder { get; set; } = new List<ProductBidder>();
	}
}
