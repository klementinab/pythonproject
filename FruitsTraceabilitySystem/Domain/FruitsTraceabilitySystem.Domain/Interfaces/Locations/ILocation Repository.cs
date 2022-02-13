using FruitsTraceabilitySystem.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
