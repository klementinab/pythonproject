using FruitsTraceabilitySystem.Domain.Models.Sortings;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Sortings
{
    public interface ISortingRepository
    {
        #region Methods
        IEnumerable<Sorting> GetAll(string? includeProperties = null);
        Sorting GetFirstOrDefault(Expression<Func<Sorting, bool>> filter, string? includeProperties = null);
        void Add(Sorting sorting);
        void Update(Sorting sorting);
        void Delete(int? Id);
        #endregion
    }
}
