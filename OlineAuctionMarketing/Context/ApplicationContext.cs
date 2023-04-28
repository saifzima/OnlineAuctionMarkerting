using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Context
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
		public DbSet<Users> Users { get; set; }
		public DbSet<Auction> Auctions { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Bidder> Bidders { get; set; }
		public DbSet<Auctioneer> Auctioneer { get; set; }
		public DbSet<AuctionBidder> AuctionBidder { get; set; }
		public DbSet<Bids> Bids { get; set; }
    }
}
