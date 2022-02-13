using FruitsTraceabilitySystem.Application.Interfaces.Locations;
using FruitsTraceabilitySystem.Application.ViewModels.Locations;
using FruitsTraceabilitySystem.Domain.Models.SeedRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitsTraceabilitySystem.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SeedRole.RoleAdmin)]
    public class LocationController : Controller
    {
        #region Properties
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
        }

        #endregion


        #region Methods
        public IActionResult Index()
        {
            IEnumerable<LocationViewModel>locations = _locationService.GetAll();
            return View(locations);
        }
        public IActionResult Created()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(LocationViewModel location)
        {
            if (ModelState.IsValid)
            {
                _locationService.Add(location);
                TempData["success"] = "Location created successfully";
                return RedirectToAction("Index");
            }
            return View(location);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var location = _locationService.GetFirstOrDefault(Id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LocationViewModel location)
        {
            if (ModelState.IsValid)
            {
                _locationService.Update(location);
                TempData["success"] = "Location edit successfully";
                return RedirectToAction("Index");
            }
            return View(location);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var location = _locationService.GetFirstOrDefault(Id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            _locationService.Delete(Id);
            TempData["success"] = "Location delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
