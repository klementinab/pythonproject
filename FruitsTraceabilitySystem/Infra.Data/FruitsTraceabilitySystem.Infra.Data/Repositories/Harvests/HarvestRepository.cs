using FruitsTraceabilitySystem.Domain.Interfaces.Harvests;
using FruitsTraceabilitySystem.Domain.Models.Harvests;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Harvests
{
    public class HarvestRepository : IHarvestRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Harvest> _dbSet;
        #endregion

        #region Constructors
        public HarvestRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            this._dbSet = _applicationDb.Set<Harvest>();
        }
        #endregion

        #region Methods
        public IEnumerable<Harvest> GetAll(string? includeProperties = null)
        {
            IQueryable<Harvest> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Harvest GetFirstOrDefault(Expression<Func<Harvest, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Harvest> query = _dbSet;
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
        public void Add(Harvest harvest)
        {
            _applicationDb.Harvests.Add(harvest);
            _applicationDb.SaveChanges();
        }
        public void Update(Harvest harvest)
        {
            _applicationDb.Harvests.Update(harvest);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var harvest = _applicationDb.Harvests.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Harvests.Remove(harvest);
            _applicationDb.SaveChanges();
        }
        #endregion
    }
}
