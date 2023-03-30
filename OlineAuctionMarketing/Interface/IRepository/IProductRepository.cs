using OlineAuctionMarketing.Models.Entities;
using System.Linq.Expressions;

namespace OlineAuctionMarketing.Interface.IRepository
{
    public interface IProductRepository
    {
        Product Create(Product product);
        bool Delete(Product product);
        IList<Product> GetAllProducts(Expression<Func<Product, bool>> expression);
        Product Get(Expression<Func<Product, bool>> expression);
        Product GetById(int id);
        Product Update(Product product);
    }
}
