using FruitsTraceabilitySystem.Domain.Models.Products;
using FruitsTraceabilitySystem.Domain.Models.Sortings;
using FruitsTraceabilitySystem.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Harvests
{
    public class Harvest
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<Sorting>? Sortings { get; set; }
        #endregion
    }
}
