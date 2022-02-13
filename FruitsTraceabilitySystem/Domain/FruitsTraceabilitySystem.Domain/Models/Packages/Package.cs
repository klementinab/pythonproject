using FruitsTraceabilitySystem.Domain.Models.Packangins;
using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Packages
{
    public class Package
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Quantity { get; set; }

        public ICollection<Packanging>? Packangings { get; set; }
        #endregion
    }
}
