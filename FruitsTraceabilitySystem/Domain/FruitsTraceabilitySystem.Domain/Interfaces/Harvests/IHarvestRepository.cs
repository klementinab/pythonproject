using FruitsTraceabilitySystem.Domain.Models.Harvests;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Harvests
{
    public interface IHarvestRepository
    {
        #region Methods
        IEnumerable<Harvest> GetAll(string? includeProperties = null);
        Harvest GetFirstOrDefault(Expression<Func<Harvest, bool>> filter, string? includeProperties = null);
        void Add(Harvest harvest);
        void Update(Harvest harvest);   
        void Delete(int? Id);
        #endregion
    }
}
