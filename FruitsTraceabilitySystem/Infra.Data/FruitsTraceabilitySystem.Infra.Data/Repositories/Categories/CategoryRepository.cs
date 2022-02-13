using FruitsTraceabilitySystem.Domain.Interfaces.Categories;
using FruitsTraceabilitySystem.Domain.Models.Categories;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Category> _dbSet;
        #endregion

        #region Constructors
        public CategoryRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            this._dbSet = _applicationDb.Set<Category>();
        }
        #endregion

        #region Methods
        public IEnumerable<Category> GetAll(string? includeProperties = null)
        {
            IQueryable<Category> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Category> query = _dbSet;
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
        public void Add(Category category)
        {
            _applicationDb.Categories.Add(category);
            _applicationDb.SaveChanges();
        }
        public void Update(Category category)
        {
            _applicationDb.Categories.Update(category);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var category = _applicationDb.Categories.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Categories.Remove(category);
            _applicationDb.SaveChanges();
        }
        #endregion
    }
}
