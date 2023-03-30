using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
    public interface IBidderRepository
    {
        Bidder Create(Bidder bidder);
        bool Delete(Bidder bidder);
        IList<Bidder> GetAllBidders(Expression<Func<Bidder, bool>> expression);
        Bidder Get(Expression<Func<Bidder, bool>> expression);
        Bidder GetBidderId(int id);
        Bidder GetBidderByEmail(string email);
        Bidder Update(Bidder bidder);
    }
}
