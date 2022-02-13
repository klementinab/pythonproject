using FruitsTraceabilitySystem.Domain.Interfaces.Packangins;
using FruitsTraceabilitySystem.Domain.Models.Packangins;
using FruitsTraceabilitySystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Infra.Data.Repositories.Packangins
{
    public class PackangingRepository : IPackangingRepository
    {
        #region Properties
        private readonly ApplicationDbContext _applicationDb;
        internal DbSet<Packanging> _dbSet;
        #endregion

        #region Constructors
        public PackangingRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            this._dbSet = _applicationDb.Set<Packanging>();
        }
        #endregion

        #region Methods
        public IEnumerable<Packanging> GetAll(string? includeProperties = null)
        {
            IQueryable<Packanging> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public Packanging GetFirstOrDefault(Expression<Func<Packanging, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Packanging> query = _dbSet;
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
        public void Add(Packanging packangings)
        {
            _applicationDb.Packangings.Add(packangings);
            _applicationDb.SaveChanges();
        }
        public void Update(Packanging packangings)  
        {
            _applicationDb.Packangings.Update(packangings);
            _applicationDb.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var packangings = _applicationDb.Packangings.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();
            _applicationDb.Packangings.Remove(packangings);
            _applicationDb.SaveChanges();   
        }
        #endregion
    }
}
