using FruitsTraceabilitySystem.Application.ViewModels.Packages;

namespace FruitsTraceabilitySystem.Application.Interfaces.Packages
{
    public interface IPackageService
    {
        #region Methods
        IEnumerable<PackageViewModel> GetAll(string? includeProperties = null);
        PackageViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(PackageViewModel packageView);
        void Update(PackageViewModel packageView);  
        void Delete(int? Id);
        #endregion
    }
}
