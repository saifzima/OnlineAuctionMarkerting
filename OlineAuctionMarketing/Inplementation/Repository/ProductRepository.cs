using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Inplementation.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            var get = _context.Products.Include(x => x.Category).FirstOrDefault(expression);
            return get;
        }

        public IList<Product> GetAllProducts(Expression<Func<Product, bool>> expression)
        {
            var getAllProduct = _context.Products.Include(a => a.Category).Where(expression).ToList();
            return getAllProduct;
        }

        public Product GetById(int id)
        {
            var get = _context.Products.Include(d => d.Category).SingleOrDefault(r => r.Id == id);
            return get;
        }

        public Product Update(Product product)
        {
            _context.SaveChanges();
            return product;
        }

    }
}
