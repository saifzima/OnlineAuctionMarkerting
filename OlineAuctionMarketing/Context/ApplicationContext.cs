using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Enums;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                Id = 1,
                FirstName = "Aduni",
                LastName = "Ibah",
                UserName = "Admin",
                ProfilePicture = "logo.jpg",
                Email = "Ibah@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("mustaeenah"),
                phoneNumber = "08083901146",
                Role = UserRole.Admin,
                Created = DateTime.Now,
                Modified = DateTime.Now,
            }
            );

        }
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Category>().Ha
         }*/
    }
}
