using FruitsTraceabilitySystem.Domain.Models.Categories;
using System.Linq.Expressions;

namespace FruitsTraceabilitySystem.Domain.Interfaces.Categories
{
    public interface ICategoryRepository
    {
        #region Methods
        IEnumerable<Category> GetAll(string? includeProperties = null);
        Category GetFirstOrDefault(Expression<Func<Category, bool>> filter, string? includeProperties = null);
        void Add(Category category);
        void Update(Category category);
        void Delete(int? Id);
        #endregion
    }
}
