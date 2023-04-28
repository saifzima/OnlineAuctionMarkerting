using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationContext _context;
        public AuctionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Auction Create(Auction auction)
        {
            _context.Auctions.Add(auction);
            _context.SaveChanges();
            return auction;
        }

        public bool Delete(Auction auction)
        {
            _context.Auctions.Remove(auction);
            _context.SaveChanges();
            return true;
        }

        public Auction Get(Expression<Func<Auction, bool>> expression)
        {
            var get = _context.Auctions.Include(x => x.Category).FirstOrDefault(expression);
            return get;
        }

        public IList<Auction> GetAllAuctions(Expression<Func<Auction, bool>> expression)
        {
            var getAllAuction = _context.Auctions.Include(a => a.Category).Where(expression).ToList();
            return getAllAuction;
        }

        public ICollection<AuctionBidder> GetAuctionBidder(int auctionId)
        {
            var get = _context.Auctions.Include(d => d.Bidder).Where(r => r.Id == auctionId).SelectMany(s => s.Bidder).Where(t => t.AuctionId ==auctionId).ToList();
            return get;
        }
        public Auction GetById(int id)
        {
            var get = _context.Auctions.Include(d => d.Category).SingleOrDefault(r => r.Id == id);
            return get;
        }

        public Auction Update(Auction auction)
        {
            _context.SaveChanges();
            return auction;
        }
    }
}
