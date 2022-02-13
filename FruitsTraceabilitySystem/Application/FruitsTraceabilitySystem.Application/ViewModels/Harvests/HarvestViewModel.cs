using FruitsTraceabilitySystem.Application.ViewModels.Products;
using FruitsTraceabilitySystem.Application.ViewModels.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Users;

namespace FruitsTraceabilitySystem.Application.ViewModels.Harvests
{
    public class HarvestViewModel
    {
        #region Properties
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public virtual ProductViewModel? Product { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public ICollection<SortingViewModel>? Sortings { get; set; }
        #endregion
    }
}
