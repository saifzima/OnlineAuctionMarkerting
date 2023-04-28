using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
	public class AuctioneerRepository : IAuctioneerRepository
	{
		private readonly ApplicationContext _context;
		public AuctioneerRepository(ApplicationContext context)
		{
			_context = context;
		}

		public Auctioneer Create(Auctioneer auctioneer)
		{
			_context.Auctioneer.Add(auctioneer);
			_context.SaveChanges();
			 return auctioneer;
		}

		public bool Delete(Auctioneer auctioneer)
		{
			_context.Auctioneer.Remove(auctioneer);
			_context.SaveChanges();
			return true;
		}

		public Auctioneer Get(Expression<Func<Auctioneer, bool>> expression)
		{
			var get = _context.Auctioneer.Include(x => x.Users).Include(a => a.Auctions).FirstOrDefault(expression);
			return get;
		}

		public IList<Auctioneer> GetAllAuctioneers(Expression<Func<Auctioneer, bool>> expression)
		{
			var getAllAuctioneer = _context.Auctioneer.Include(a => a.Users).Where(expression).ToList();
			return getAllAuctioneer;
		}

		public Auctioneer GetAuctioneerByEmail(string email)
		{
			var get = _context.Auctioneer.Include(a => a.Users).SingleOrDefault(a => a.Users.Email == email);
			return get;
		}

		public Auctioneer GetAuctioneerId(int id)
		{
			var get = _context.Auctioneer.Include(d => d.Users).SingleOrDefault(r => r.Id == id);
			return get;
		}

		public Auctioneer Update(Auctioneer auctioneer)
		{
			//_context.Auctioneer.Update(auctioneer);
			_context.SaveChanges();
			return auctioneer;
		}
	}
}
