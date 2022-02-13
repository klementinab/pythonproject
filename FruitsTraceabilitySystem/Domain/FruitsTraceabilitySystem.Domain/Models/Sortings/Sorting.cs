using FruitsTraceabilitySystem.Domain.Models.Harvests;
using FruitsTraceabilitySystem.Domain.Models.Packangins;
using FruitsTraceabilitySystem.Domain.Models.Products;
using FruitsTraceabilitySystem.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitsTraceabilitySystem.Domain.Models.Sortings
{
    public class Sorting
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public int? HarvestId { get; set; }
        public Harvest? Harvest { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Packanging>? Packangings { get; set; }   
        #endregion
    }
}
