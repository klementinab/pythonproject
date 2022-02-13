using FruitsTraceabilitySystem.Domain.Interfaces.Products;
using FruitsTraceabilitySystem.Domain.Models.Products;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Product> _dbSet;
        #endregion

        #region Constructors
        public ProductRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            this._dbSet = _applicationDb.Set<Product>();
        }
        #endregion

        #region Methods
        public IEnumerable<Product> GetAll(string? includeProperties = null)
        {
            IQueryable<Product> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Product> query = _dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
        public void Add(Product product)
        {
            _applicationDb.Products.Add(product);
            _applicationDb.SaveChanges();
        }
        public void Update(Product product)
        {
            _applicationDb.Products.Update(product);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        { 
            var product = _applicationDb.Products.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Products.Remove(product);
            _applicationDb.SaveChanges();
        }
        #endregion
    }
}
