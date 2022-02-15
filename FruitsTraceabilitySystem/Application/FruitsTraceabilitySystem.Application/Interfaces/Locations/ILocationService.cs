using FruitsTraceabilitySystem.Application.ViewModels.Locations;

namespace FruitsTraceabilitySystem.Application.Interfaces.Locations
{
    public interface ILocationService
    {
        #region Methods
        IEnumerable<LocationViewModel> GetAll(string? includeProperties = null);
        LocationViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(LocationViewModel locationView);
        void Update(LocationViewModel locationView);
        void Delete(int? Id);
        #endregion
    }
}
