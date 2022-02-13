using FruitsTraceabilitySystem.Application.ViewModels.Sortings;

namespace FruitsTraceabilitySystem.Application.Interfaces.Sortings
{
    public interface ISortingService
    {
        #region Methods
        IEnumerable<SortingViewModel> GetAll(string? includeProperties = null);
        SortingViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(SortingViewModel sortingView);
        void Update(SortingViewModel sortingView);
        void Delete(int? Id);
        #endregion
    }
}
