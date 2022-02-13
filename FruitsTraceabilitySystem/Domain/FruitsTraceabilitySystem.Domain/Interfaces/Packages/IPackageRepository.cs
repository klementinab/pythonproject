using FruitsTraceabilitySystem.Domain.Models.Packages;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Packages
{
    public interface IPackageRepository
    {
        #region Methods
        IEnumerable<Package> GetAll(string? includeProperties = null);
        Package GetFirstOrDefault(Expression<Func<Package, bool>> filter, string? includeProperties = null);
        void Add(Package package);
        void Update(Package package);   
        void Delete(int? Id);
        #endregion
    }
}
