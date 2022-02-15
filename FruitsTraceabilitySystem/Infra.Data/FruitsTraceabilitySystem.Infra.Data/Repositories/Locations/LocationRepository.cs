using FruitsTraceabilitySystem.Domain.Interfaces.Locations;
using FruitsTraceabilitySystem.Domain.Models.Locations;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Locations
{
    public class LocationRepository : ILocationRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Location> _dbSet;
        #endregion

        #region Constructors
        public LocationRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
            this._dbSet = _applicationDb.Set<Location>();
        }
        #endregion

        #region Methods
        public IEnumerable<Location> GetAll(string? includeProperties = null)
        {
            IQueryable<Location> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Location GetFirstOrDefault(Expression<Func<Location, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Location>? query = _dbSet;
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
        public void Add(Location location)
        {
            _applicationDb.Locations.Add(location);
            _applicationDb.SaveChanges();

        }
        public void Update(Location location)
        {
            _applicationDb.Locations.Update(location);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var location = _applicationDb.Locations?.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Locations?.Remove(location);
            _applicationDb.SaveChanges();
        }
        #endregion
    }
}
