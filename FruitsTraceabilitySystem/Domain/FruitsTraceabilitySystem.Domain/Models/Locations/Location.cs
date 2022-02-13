using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsTraceabilitySystem.Domain.Models.Locations
{
    public class Location
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string? PlaceName { get; set; }
       
        #endregion
    }
}
