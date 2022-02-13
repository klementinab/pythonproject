using FruitsTraceabilitySystem.Domain.Models.Harvests;
using FruitsTraceabilitySystem.Domain.Models.Packangins;
using FruitsTraceabilitySystem.Domain.Models.Sortings;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FruitsTraceabilitySystem.Domain.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        #region Properties
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public ICollection<Harvest>? Harvests { get; set; }
        public ICollection<Sorting>? Sortings { get; set; }
        public ICollection<Packanging>? Packangings { get; set; }
        #endregion
    }
}
