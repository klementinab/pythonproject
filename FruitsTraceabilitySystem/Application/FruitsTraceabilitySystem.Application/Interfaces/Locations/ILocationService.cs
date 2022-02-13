using FruitsTraceabilitySystem.Application.ViewModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsTraceabilitySystem.Application.Interfaces.Locations
{
    public interface ILocationService
    {
        IEnumerable<LocationViewModel> GetAll(string? includeProperties = null);
        LocationViewModel GetFirstOrDefault(int? Id, string? includeProperties = null);
        void Add(LocationViewModel locationView);
        void Update(LocationViewModel locationView);
        void Delete(int? Id);

    }
}
