using FruitsTraceabilitySystem.Domain.Interfaces.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Sortings;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Sortings
{
    public class SortingRepository : ISortingRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Sorting> _dbSet;
        #endregion

        #region Constructors
        public SortingRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            this._dbSet = _applicationDb.Set<Sorting>();
        }
        #endregion

        #region Methods
        public IEnumerable<Sorting> GetAll(string? includeProperties = null)
        {
            IQueryable<Sorting> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Sorting GetFirstOrDefault(Expression<Func<Sorting, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Sorting> query = _dbSet;
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
        public void Add(Sorting sorting)
        {
            _applicationDb.Sortings.Add(sorting);
            _applicationDb.SaveChanges();
        }
        public void Update(Sorting sorting)
        {
            _applicationDb.Sortings.Update(sorting);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var sorting = _applicationDb.Sortings.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Sortings.Remove(sorting);
            _applicationDb.SaveChanges();
        }
        #endregion
    }
}
