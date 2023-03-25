using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
	public interface IUserRepository
	{
		Users Create(Users users);
		Users Login(string email, string password);
		void Delete(Users users);
		Users GetById(int id);
		Users Get(Expression<Func<Users, bool>> expression);
		Users GetByEmail(string email);
		Users UpdateRole(Users users);
	}
}
