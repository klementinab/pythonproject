using FruitsTraceabilitySystem.Application.ViewModels.Harvests;

namespace FruitsTraceabilitySystem.Application.Interfaces.Harvests
{
    public interface IHarvestService
    {
        #region Methods
        IEnumerable<HarvestViewModel> GetAll(string? includeProperties = null);
        HarvestViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(HarvestViewModel harvestView); 
        void Update(HarvestViewModel harvestView);  
        void Delete(int? Id);
        #endregion
    }
}
