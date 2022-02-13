using FruitsTraceabilitySystem.Domain.Interfaces.Packages;
using FruitsTraceabilitySystem.Domain.Models.Packages;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Packages
{
    public class PackageRepository : IPackageRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Package> _dbSet;
        #endregion

        #region Constructors
        public PackageRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            this._dbSet = _applicationDb.Set<Package>();
        }
        #endregion

        #region Methods
        public IEnumerable<Package> GetAll(string? includeProperties = null)
        {
            IQueryable<Package> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Package GetFirstOrDefault(Expression<Func<Package, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Package> query = _dbSet;
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
        public void Add(Package package)
        {
            _applicationDb.Packages.Add(package);
            _applicationDb.SaveChanges();
        }
        public void Update(Package package)
        {
            _applicationDb.Packages.Update(package);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var package = _applicationDb.Packages.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Packages.Remove(package);
            _applicationDb.SaveChanges();
        }
        #endregion
    }
}
