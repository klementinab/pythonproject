using FruitsTraceabilitySystem.Application.ViewModels.Harvests;
using FruitsTraceabilitySystem.Application.ViewModels.Packangings;
using FruitsTraceabilitySystem.Domain.Models.Users;

namespace FruitsTraceabilitySystem.Application.ViewModels.Sortings
{
    public class SortingViewModel
    {
        #region Properties  
        public int Id { get; set; }
        public int? HarvestId { get; set; }
        public HarvestViewModel? Harvest { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string? ProductName { get; set; }

        public ICollection<PackangingViewModel>? Packangings { get; set; }
        #endregion
    }
}
