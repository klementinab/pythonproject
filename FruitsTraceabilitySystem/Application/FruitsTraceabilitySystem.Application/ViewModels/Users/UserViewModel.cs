using FruitsTraceabilitySystem.Domain.Models.Users;

namespace FruitsTraceabilitySystem.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser>? Users { get; set; }
    }
}
