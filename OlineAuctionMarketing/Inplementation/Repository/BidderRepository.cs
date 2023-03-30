using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
    public class BidderRepository :IBidderRepository
    {
        private readonly ApplicationContext _context;
        public BidderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Bidder Create(Bidder bidder)
        {
            _context.Bidders.Add(bidder);
            _context.SaveChanges();
            return bidder;
        }

        public bool Delete(Bidder bidder)
        {
            _context.Bidders.Remove(bidder);
            _context.SaveChanges();
            return true;
        }

        public Bidder Get(Expression<Func<Bidder, bool>> expression)
        {
            var get = _context.Bidders.Include(x => x.Users).Include(a => a.ProductBidder).FirstOrDefault(expression);
            return get;
        }

        public IList<Bidder> GetAllBidders(Expression<Func<Bidder, bool>> expression)
        {
            var getAllBidder = _context.Bidders.Include(a => a.Users).Where(expression).ToList();
            return getAllBidder;
        }

        public Bidder GetBidderByEmail(string email)
        {
            var get = _context.Bidders.Include(a => a.Users).SingleOrDefault(a => a.Users.Email == email);
            return get;
        }
        public Bidder GetBidderId(int id)
        {
            var get = _context.Bidders.Include(d => d.Users).SingleOrDefault(r => r.Id == id);
            return get;
        }

        public Bidder Update(Bidder bidder)
        {
            _context.SaveChanges();
            return bidder;
        }
    }
}
