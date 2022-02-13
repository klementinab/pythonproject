using FruitsTraceabilitySystem.Application.ViewModels.Products;

namespace FruitsTraceabilitySystem.Application.Interfaces.Products
{
    public interface IProductService
    {
        #region Methods
        IEnumerable<ProductViewModel> GetAll(string? includeProperties = null);
        ProductViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(ProductViewModel productView);
        void Update(ProductViewModel productView);
        void Delete(int? Id);
        #endregion
    }
}
