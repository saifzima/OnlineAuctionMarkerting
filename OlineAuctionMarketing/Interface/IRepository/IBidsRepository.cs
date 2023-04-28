using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
    public interface IBidsRepository
    {
        Bids Create(Bids bids);
        bool Delete(Bids bids);
        IList<Bids> GetAllBids(Expression<Func<Bids, bool>> expression);
        Bids Get(Expression<Func<Bids, bool>> expression);
        Bids GetBidsId(int id);
        Bids Update(Bids bids);

    }
}
