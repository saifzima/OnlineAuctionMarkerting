namespace OlineAuctionMarketing.Models.Entities
{
	public class Category : BaseEntities
	{
		public IList<Product> Products { get; set; } = new List<Product>();
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsAvalible { get; set; }
	}
}
