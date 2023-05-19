using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.Entities
{
	public class Auction :BaseEntities
	{
		public string Image { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public DateTime StartingTime { get; set; }
		public DateTime EndingTime { get; set; } = DateTime.MinValue;
		public double StartingPrice { get; set; }
        public Condition ItemCondition { get; set; }
        public int AuctioneerId { get; set; }
		public Auctioneer Auctioneer { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public IList<AuctionBidder> Bidder { get; set; } = new List<AuctionBidder>();
	}
}
