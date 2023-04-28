using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
    public interface IAuctionRepository
    {
        Auction Create(Auction auction);
        bool Delete(Auction auction);
        IList<Auction> GetAllAuctions(Expression<Func<Auction, bool>> expression);
        Auction Get(Expression<Func<Auction, bool>> expression);
        ICollection<AuctionBidder> GetAuctionBidder(int auctionId);
        Auction GetById(int id);
        Auction Update(Auction auction);
    }
}
