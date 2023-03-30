using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        bool Delete(Category category);
        IList<Category> GetAllCategories(Expression<Func<Category, bool>> expression);
        Category Get(Expression<Func<Category, bool>> expression);
        Category GetCategoryId(int id);
        Category Update(Category category);
    }
}
