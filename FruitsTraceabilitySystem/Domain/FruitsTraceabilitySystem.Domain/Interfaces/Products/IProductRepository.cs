using FruitsTraceabilitySystem.Domain.Models.Products;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Products
{
    public interface IProductRepository
    {
        #region Methods
        IEnumerable<Product> GetAll(string? includeProperties = null);
        Product GetFirstOrDefault(Expression<Func<Product, bool>> filter, string? includeProperties = null);
        void Add(Product product);
        void Update(Product product);
        void Delete(int? Id);   
        #endregion
    }
}
