using FruitsTraceabilitySystem.Domain.Models.Locations;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Locations
{
    public interface ILocationRepository
    {
        #region Methods
        IEnumerable<Location> GetAll(string? includeProperties = null);
        Location GetFirstOrDefault(Expression<Func<Location, bool>> filter, string? includeProperties = null);
        void Add(Location location);
        void Update(Location location);
        void Delete(int? Id);
        #endregion
    }
}
