using FruitsTraceabilitySystem.Domain.Interfaces.Categories;
using FruitsTraceabilitySystem.Domain.Interfaces.Harvests;
using FruitsTraceabilitySystem.Domain.Interfaces.Packages;
using FruitsTraceabilitySystem.Domain.Interfaces.Packangins;
using FruitsTraceabilitySystem.Domain.Interfaces.Products;
using FruitsTraceabilitySystem.Domain.Interfaces.Sortings;

namespace FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Methods
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IHarvestRepository Harvest { get; }
        ISortingRepository Sorting { get; }
        IPackageRepository Package { get; }
        IPackangingRepository Packanging { get; }
        #endregion
    }
}
