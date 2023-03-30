using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }

        public Category Get(Expression<Func<Category, bool>> expression)
        {
            var get = _context.Categories.Include(x => x.Products).FirstOrDefault(expression);
            return get;
        }

        public IList<Category> GetAllCategories(Expression<Func<Category, bool>> expression)
        {
            var getAllCategory = _context.Categories.Include(a => a.Products).Where(expression).ToList();
            return getAllCategory;
        }


        public Category GetCategoryId(int id)
        {
            var get = _context.Categories.Include(d => d.Products).SingleOrDefault(r => r.Id == id);
            return get;
        }

        public Category Update(Category category)
        {
            _context.SaveChanges();
            return category;
        }
    }
}
