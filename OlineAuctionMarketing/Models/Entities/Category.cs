namespace OlineAuctionMarketing.Models.Entities
{
	public class Category : BaseEntities
	{
		public IList<Auction> Auctions { get; set; } = new List<Auction>();
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsAvalible { get; set; }
	}
}
