using FruitsTraceabilitySystem.Application.ViewModels.Packangings;

namespace FruitsTraceabilitySystem.Application.ViewModels.Packages
{
    public class PackageViewModel
    {
        #region Properties  
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Quantity { get; set; }

        public ICollection<PackangingViewModel>? Packangings { get; set; }  
        #endregion
    }
}
