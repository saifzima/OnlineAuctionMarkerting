using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;
		public UserRepository(ApplicationContext context)
		{
			_context = context;
		}

		public Users Create(Users users)
		{
			_context.Users.Add(users);
			_context.SaveChanges();
			return users;
		}

		public void Delete(Users users)
		{
			_context.Users.Remove(users);
			_context.SaveChanges();
		}

		public Users Get(Expression<Func<Users, bool>> expression)
		{
			var get = _context.Users.Include(x => x.Auctioneer).FirstOrDefault(expression);
			return get;
		}

		public Users GetByEmail(string email)
		{
			var user = _context.Users.SingleOrDefault(x => x.Email == email);
			return user;
		}

		public Users GetById(int id)
		{
			var user = _context.Users.SingleOrDefault(x => x.Id == id);
			return user;
		}

		public Users Login(string email, string password)
		{
			var userr = _context.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
			return userr;
		}

		public Users UpdateRole(Users users)
		{
			//_context.Users.Update(users);
			_context.SaveChanges();
			return users;
		}
	}
}
