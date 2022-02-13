using FruitsTraceabilitySystem.Application.ViewModels.Products;

namespace FruitsTraceabilitySystem.Application.ViewModels.Categories
{
    public class CategoryViewModel
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ProductViewModel>? Products { get; set; }
        #endregion
    }
}
