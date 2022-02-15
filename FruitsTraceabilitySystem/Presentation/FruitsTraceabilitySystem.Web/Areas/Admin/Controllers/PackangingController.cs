using FruitsTraceabilitySystem.Application.Interfaces.Harvests;
using FruitsTraceabilitySystem.Application.Interfaces.Packages;
using FruitsTraceabilitySystem.Application.Interfaces.Packangings;
using FruitsTraceabilitySystem.Application.Interfaces.Sortings;
using FruitsTraceabilitySystem.Application.ViewModels.Harvests;
using FruitsTraceabilitySystem.Application.ViewModels.Packangings;
using FruitsTraceabilitySystem.Application.ViewModels.Sortings;
using FruitsTraceabilitySystem.Domain.Models.SeedRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace FruitsTraceabilitySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SeedRole.RoleAdmin)]
    public class PackangingController : Controller
    {
        #region Properties
        private readonly IPackangingService _packangingService;
        private readonly ISortingService _sortingService;
        private readonly IHarvestService _harvestService;
        private readonly IPackageService _packageService;
        #endregion

        #region Constructors
        public PackangingController(IPackangingService packangingService, ISortingService sortingService, IHarvestService harvestService, IPackageService packageService)
        {
            _packangingService = packangingService ?? throw new ArgumentNullException(nameof(packangingService));
            _sortingService = sortingService ?? throw new ArgumentNullException(nameof(sortingService));
            _harvestService = harvestService ?? throw new ArgumentNullException(nameof(harvestService));
            _packageService = packageService ?? throw new ArgumentNullException(nameof(packageService));
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            List<PackangingViewModel> packangings = _packangingService.GetAll(includeProperties: "ProductSorting,Package,User").ToList();
            packangings.ForEach(x =>
            {
                var sortings = _sortingService.GetFirstOrDefault(x.ProductSortingId, includeProperties: "Harvest");
                foreach (var sorting in sortings.ToString())
                {
                    x.ProductSortingName = _harvestService.GetFirstOrDefault(sortings.HarvestId, includeProperties: "Product").Product.Name;
                }
            });
            return View(packangings);
        }
        public IActionResult Created()
        {
            IEnumerable<SelectListItem> PackageList = _packageService.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.PackageList = PackageList;
            List<SortingViewModel> data = _sortingService.GetAll(includeProperties: "Harvest").ToList();
            data.ForEach(x =>
            {
                x.ProductName = _harvestService.GetFirstOrDefault(x.HarvestId, includeProperties: "Product").Product.Name;
            });
            IEnumerable<SelectListItem> SortingList = data.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.Id.ToString()
            });
            ViewBag.SortingList = SortingList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(PackangingViewModel packanging)
        {
            if (ModelState.IsValid)
            {
                packanging.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _packangingService.Add(packanging);
                TempData["success"] = "Packanging created successfully";
                return RedirectToAction("Index");
            }
            return View(packanging);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var packanging = _packangingService.GetFirstOrDefault(Id, includeProperties: "ProductSorting,Package,User");
            IEnumerable<SelectListItem> PackageList = _packageService.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            ViewBag.PackageList = PackageList;
            var sortingServices = _sortingService.GetFirstOrDefault(packanging.ProductSortingId, includeProperties: "Harvest");
            packanging.ProductSortingId = _harvestService.GetFirstOrDefault(sortingServices.Id, includeProperties: "Product").Product.Id;
            packanging.ProductSortingName = _harvestService.GetFirstOrDefault(sortingServices.Id, includeProperties: "Product").Product.Name;
            
            ViewBag.ProductList = packanging;
            if (packanging == null)
            {
                return NotFound();
            }
            return View(packanging);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PackangingViewModel packangingView)
        {
            if (ModelState.IsValid)
            {
                _packangingService.Update(packangingView);
                TempData["success"] = "Packanging edit successfully";
                return RedirectToAction("Index");
            }
            return View(packangingView);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var packangingView = _packangingService.GetFirstOrDefault(Id);
            if (packangingView == null)
            {
                return NotFound();
            }
            return View(packangingView);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            _packangingService.Delete(Id);
            TempData["success"] = "Packanging delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
