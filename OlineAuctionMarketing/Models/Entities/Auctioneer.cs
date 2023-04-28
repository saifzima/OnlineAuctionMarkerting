namespace OlineAuctionMarketing.Models.Entities
{
	public class Auctioneer : BaseEntities
	{
		public int UsersId { get; set; }
		public Users Users { get; set; }
		public IList<Auction> Auctions { get; set; } = new List<Auction>();
	}
}
