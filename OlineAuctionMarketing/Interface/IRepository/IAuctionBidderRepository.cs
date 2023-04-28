using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository;

public interface IAuctionBidderRepository
{
    ICollection<AuctionBidder> Get(Func<AuctionBidder, bool> expression);
}
