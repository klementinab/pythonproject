using FruitsTraceabilitySystem.Domain.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Categories
{
    public class Category
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
        #endregion
    }
}
