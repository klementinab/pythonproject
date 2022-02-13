using FruitsTraceabilitySystem.Application.ViewModels.Categories;
using FruitsTraceabilitySystem.Application.ViewModels.Harvests;
using FruitsTraceabilitySystem.Application.ViewModels.Sortings;

namespace FruitsTraceabilitySystem.Application.ViewModels.Products
{
    public class ProductViewModel
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public virtual CategoryViewModel? Category { get; set; }

        public ICollection<HarvestViewModel>? Harvests { get; set; }
        #endregion
    }
}
