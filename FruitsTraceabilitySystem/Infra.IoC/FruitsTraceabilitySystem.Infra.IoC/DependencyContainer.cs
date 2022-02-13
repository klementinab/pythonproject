using FruitsTraceabilitySystem.Application.Interfaces.Categories;
using FruitsTraceabilitySystem.Application.Interfaces.Harvests;
using FruitsTraceabilitySystem.Application.Interfaces.Locations;
using FruitsTraceabilitySystem.Application.Interfaces.Packages;
using FruitsTraceabilitySystem.Application.Interfaces.Packangings;
using FruitsTraceabilitySystem.Application.Interfaces.Products;
using FruitsTraceabilitySystem.Application.Interfaces.Sortings;
using FruitsTraceabilitySystem.Application.Mappings;
using FruitsTraceabilitySystem.Application.Services.Categories;
using FruitsTraceabilitySystem.Application.Services.Harvests;
using FruitsTraceabilitySystem.Application.Services.Locations;
using FruitsTraceabilitySystem.Application.Services.Packages;
using FruitsTraceabilitySystem.Application.Services.Packangings;
using FruitsTraceabilitySystem.Application.Services.Products;
using FruitsTraceabilitySystem.Application.Services.Sortings;
using FruitsTraceabilitySystem.Domain.Interfaces.Categories;
using FruitsTraceabilitySystem.Domain.Interfaces.Harvests;
using FruitsTraceabilitySystem.Domain.Interfaces.Locations;
using FruitsTraceabilitySystem.Domain.Interfaces.Packages;
using FruitsTraceabilitySystem.Domain.Interfaces.Packangins;
using FruitsTraceabilitySystem.Domain.Interfaces.Products;
using FruitsTraceabilitySystem.Domain.Interfaces.Sortings;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Categories;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Harvests;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Locations;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Packages;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Packangins;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Products;
using FruitsTraceabilitySystem.Infra.Data.Repositories.Sortings;
using FruitsTraceabilitySystem.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FruitsTraceabilitySystem.Infra.IoC
{
    public class DependencyContainer
    {
        #region Methods
        public static void RegisterService(IServiceCollection services)
        {
            //Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IHarvestService, HarvestService>();
            services.AddScoped<ISortingService, SortingService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IPackangingService, PackangingService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingConfig));

            //Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IHarvestRepository, HarvestRepository>();
            services.AddScoped<ISortingRepository, SortingRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackangingRepository, PackangingRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
        }
        #endregion
    }
}
