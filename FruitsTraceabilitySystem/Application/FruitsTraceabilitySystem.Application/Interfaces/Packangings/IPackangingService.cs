using FruitsTraceabilitySystem.Application.ViewModels.Packangings;

namespace FruitsTraceabilitySystem.Application.Interfaces.Packangings
{
    public interface IPackangingService
    {
        #region Methods
        IEnumerable<PackangingViewModel> GetAll(string? includeProperties = null);
        PackangingViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(PackangingViewModel packangingView);
        void Update(PackangingViewModel packangingView);
        void Delete(int? Id);
        #endregion
    }
}
