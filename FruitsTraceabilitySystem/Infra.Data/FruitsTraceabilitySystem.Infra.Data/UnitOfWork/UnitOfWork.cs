using FruitsTraceabilitySystem.Domain.Interfaces.Categories;
using FruitsTraceabilitySystem.Domain.Interfaces.Harvests;
using FruitsTraceabilitySystem.Domain.Interfaces.Packages;
using FruitsTraceabilitySystem.Domain.Interfaces.Packangins;
using FruitsTraceabilitySystem.Domain.Interfaces.Products;
using FruitsTraceabilitySystem.Domain.Interfaces.Sortings;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Infra.Data.Context;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Categories;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Harvests;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Packages;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Packangins;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Products;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Sortings;

namespace FruitsTraceabilitySystem.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private ApplicationDbContext _applicationDb;
        public IProductRepository Product { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IHarvestRepository Harvest { get; private set; }
        public ISortingRepository Sorting { get; private set; }
        public IPackageRepository Package { get; private set; }
        public IPackangingRepository Packanging { get; private set; }
        #endregion

        #region Constructors
        public UnitOfWork(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb ?? throw new ArgumentNullException(nameof(applicationDb));
            Product = new ProductRepository(_applicationDb);
            Category = new CategoryRepository(_applicationDb);
            Harvest = new HarvestRepository(_applicationDb);
            Sorting = new SortingRepository(_applicationDb);
            Package = new PackageRepository(_applicationDb);
            Packanging = new PackangingRepository(_applicationDb);
        }
        #endregion
    }
}
