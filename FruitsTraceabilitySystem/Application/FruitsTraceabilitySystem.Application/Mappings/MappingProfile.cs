using AutoMapper;
using FruitsTraceabilitySystem.Application.ViewModels.Categories;
using FruitsTraceabilitySystem.Application.ViewModels.Harvests;
using FruitsTraceabilitySystem.Application.ViewModels.Packages;
using FruitsTraceabilitySystem.Application.ViewModels.Packangings;
using FruitsTraceabilitySystem.Application.ViewModels.Products;
using FruitsTraceabilitySystem.Application.ViewModels.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Categories;
using FruitsTraceabilitySystem.Domain.Models.Harvests;
using FruitsTraceabilitySystem.Domain.Models.Packages;
using FruitsTraceabilitySystem.Domain.Models.Packangins;
using FruitsTraceabilitySystem.Domain.Models.Products;
using FruitsTraceabilitySystem.Domain.Models.Sortings;

namespace FruitsTraceabilitySystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        #region Constructors
        public MappingProfile()
        {
            //Views To Domain
            CreateMap<List<CategoryViewModel>, Category>().ReverseMap();
            CreateMap<List<ProductViewModel>, Product>().ReverseMap();
            CreateMap<HarvestViewModel, Harvest>().ReverseMap();
            CreateMap<SortingViewModel, Sorting>().ReverseMap();
            CreateMap<PackageViewModel, Package>().ReverseMap();
            CreateMap<PackangingViewModel, Packanging>().ReverseMap();


            //Domain To Views
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Harvest, HarvestViewModel>().ReverseMap();
            CreateMap<Sorting, SortingViewModel>().ReverseMap();
            CreateMap<Package, PackageViewModel>().ReverseMap();
            CreateMap<Packanging, PackangingViewModel>().ReverseMap();
        }
        #endregion
    }
}
