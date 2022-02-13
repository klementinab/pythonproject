using FruitsTraceabilitySystem.Domain.Models.Packangins;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Packangins
{
    public interface IPackangingRepository
    {
        #region Methods
        IEnumerable<Packanging> GetAll(string? includeProperties = null);
        Packanging GetFirstOrDefault(Expression<Func<Packanging, bool>> filter, string? includeProperties = null);
        void Add(Packanging packangings);
        void Update(Packanging packangings);
        void Delete(int? Id);
        #endregion
    }
}
