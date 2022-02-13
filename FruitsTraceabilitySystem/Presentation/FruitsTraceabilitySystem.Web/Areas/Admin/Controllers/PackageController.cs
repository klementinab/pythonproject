using FruitsTraceabilitySystem.Application.Interfaces.Packages;
using FruitsTraceabilitySystem.Application.ViewModels.Packages;
using FruitsTraceabilitySystem.Domain.Models.SeedRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitsTraceabilitySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SeedRole.RoleAdmin)]
    public class PackageController : Controller
    {
        #region Properties
        private readonly IPackageService _packageService;
        #endregion

        #region Constructors
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService ?? throw new ArgumentNullException(nameof(packageService));
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<PackageViewModel> packages = _packageService.GetAll();
            return View(packages);
        }
        public IActionResult Created()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(PackageViewModel package)
        {
            if (ModelState.IsValid)
            {
                _packageService.Add(package);
                TempData["success"] = "Package created successfully";
                return RedirectToAction("Index");
            }
            return View(package);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var package = _packageService.GetFirstOrDefault(Id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PackageViewModel packageView)
        {
            if (ModelState.IsValid)
            {
                _packageService.Update(packageView);
                TempData["success"] = "Package edit successfully";
                return RedirectToAction("Index");
            }
            return View(packageView);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var packageView = _packageService.GetFirstOrDefault(Id);
            if (packageView == null)
            {
                return NotFound();
            }
            return View(packageView);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            _packageService.Delete(Id);
            TempData["success"] = "Package delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}