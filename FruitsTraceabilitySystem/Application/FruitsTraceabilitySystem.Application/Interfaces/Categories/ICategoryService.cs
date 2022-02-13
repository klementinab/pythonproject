using FruitsTraceabilitySystem.Application.ViewModels.Categories;

namespace FruitsTraceabilitySystem.Application.Interfaces.Categories
{
    public interface ICategoryService
    {
        #region Methods
        IEnumerable<CategoryViewModel> GetAll(string? includeProperties = null);
        CategoryViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(CategoryViewModel categoryView);
        void Update(CategoryViewModel categoryView);
        void Delete(int? Id);
        #endregion
    }
}
