using FruitsTraceabilitySystem.Domain.Models.Categories;
using FruitsTraceabilitySystem.Domain.Models.Harvests;
using FruitsTraceabilitySystem.Domain.Models.Packangins;
using FruitsTraceabilitySystem.Domain.Models.Sortings;
using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Products
{
    public class Product
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Quantity { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Harvest>? Harvests { get; set; }
        public ICollection<Packanging>? Packangings { get; set; }
        //public ICollection<Packanging>? Packangings { get; set; }          
        #endregion
    }
}
