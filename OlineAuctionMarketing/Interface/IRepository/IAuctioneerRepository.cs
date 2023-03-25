using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
	public interface IAuctioneerRepository
	{
		Auctioneer Create(Auctioneer auctioneer);
		bool Delete(Auctioneer auctioneer);
		IList<Auctioneer> GetAllAuctioneers(Expression<Func<Auctioneer, bool>> expression);
		Auctioneer Get(Expression<Func<Auctioneer, bool>> expression);
		Auctioneer GetAuctioneerId(int id);
		Auctioneer GetAuctioneerByEmail(string email);
		Auctioneer Update(Auctioneer auctioneer);

	}
}
