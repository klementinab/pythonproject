using FruitsTraceabilitySystem.Domain.Models.Packages;
using FruitsTraceabilitySystem.Domain.Models.Products;
using FruitsTraceabilitySystem.Domain.Models.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Packangins
{
    public class Packanging
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public int? PackageId { get; set; }
        public Package? Package { get; set; }
        public int? ProductSortingId { get; set; }
        public Sorting? ProductSorting { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int? ProductId { get; set; }
        public Product? Products { get; set; }
        #endregion
    }
}
