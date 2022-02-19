using FruitsTraceabilitySystem.Application.ViewModels.Packages;
using FruitsTraceabilitySystem.Application.ViewModels.Products;
using FruitsTraceabilitySystem.Application.ViewModels.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Users;

namespace FruitsTraceabilitySystem.Application.ViewModels.Packangings
{
    public class PackangingViewModel
    {
        #region Properties
        public int Id { get; set; }
        public int? PackageId { get; set; }
        public PackageViewModel? Package { get; set; }
        public int? ProductSortingId { get; set; }
        public SortingViewModel? ProductSorting { get; set; }
        public int? ProductId { get; set; }
        public ProductViewModel? Products { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string? ProductSortingName { get; set; }


        #endregion
    }
}
