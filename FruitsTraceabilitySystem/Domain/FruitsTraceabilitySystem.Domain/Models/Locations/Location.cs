using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Locations
{
    public class Location
    {
        #region Properties
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? PlaceName { get; set; }
        #endregion
    }
}
