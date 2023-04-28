using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
    public class BidsRepository :IBidsRepository
    {
        private readonly ApplicationContext _context;
        public BidsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Bids Create(Bids bids)
        {
            _context.Bids.Add(bids);
            _context.SaveChanges();
            return bids;
        }

        public bool Delete(Bids bids)
        {
            _context.Bids.Remove(bids);
            _context.SaveChanges();
            return true;
        }

        public Bids Get(Expression<Func<Bids, bool>> expression)
        {
            var get = _context.Bids.Include(x => x.Bidder).FirstOrDefault(expression);
            return get;
        }
        public IList<Bids> GetAllBids(Expression<Func<Bids, bool>> expression)
        {
            var getAllBids = _context.Bids.Include(a => a.Bidder).Where(expression).ToList();
            return getAllBids;
        }

        public Bids GetBidsId(int id)
        {
            var get = _context.Bids.Include(d => d.Bidder).SingleOrDefault(r => r.Id == id);
            return get;
        }

        public Bids Update(Bids bids)
        {
            _context.SaveChanges();
            return bids;
        }
    }
}
