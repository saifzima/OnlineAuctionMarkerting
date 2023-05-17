using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Inplementation.Repository;

public class AuctionBidderRepository : IAuctionBidderRepository
{
    private readonly ApplicationContext _context;

    public AuctionBidderRepository(ApplicationContext context)
    {
        _context = context;
    }
    public AuctionBidder Create(AuctionBidder auctioneer)
    {
        _context.AuctionBidder.Add(auctioneer);
        _context.SaveChanges();
        return auctioneer;
    }
    public ICollection<AuctionBidder> Get(Func<AuctionBidder, bool> expression)
    {
        var auctionBidder = _context.AuctionBidder.Include(x => x.Bidder).Include(y => y.Auction).Where(expression).ToList();
        return auctionBidder;
    }
}
