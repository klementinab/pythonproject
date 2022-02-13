using FruitsTraceabilitySystem.Application.Interfaces.Harvests;
using FruitsTraceabilitySystem.Application.Interfaces.Sortings;
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
    public class SortingController : Controller
    {
        #region Properties
        private readonly IHarvestService _harvestService;
        private readonly ISortingService _sortingService;
        #endregion

        #region Constructors
        public SortingController(IHarvestService harvestService, ISortingService sortingService)
        {
            _harvestService = harvestService ?? throw new ArgumentNullException(nameof(harvestService));
            _sortingService = sortingService ?? throw new ArgumentNullException(nameof(sortingService));
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            List<SortingViewModel> harvests = _sortingService.GetAll(includeProperties: "Harvest,User").ToList();
            harvests.ForEach(x =>
            {
                x.ProductName = _harvestService.GetFirstOrDefault(x.HarvestId, includeProperties: "Product,User").Product.Name;
            });
            //IEnumerable<SortingViewModel> harvests = _sortingService.GetAll(includeProperties: "Harvest,User").ToList();
            //foreach (var harvest in harvests)
            //{
            //    harvest.ProductName = _harvestService.GetFirstOrDefault(harvest.HarvestId, includeProperties: "Product,User").Product.Name;
            //}
            return View(harvests);
        }
        public IActionResult Created()
        {
            IEnumerable<SelectListItem> ProductList = _harvestService.GetAll(includeProperties: "Product,User")
               .Select(x => new SelectListItem
               {
                   Text = x.Product.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.ProductList = ProductList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(SortingViewModel sorting)
        {
            if (ModelState.IsValid)
            {
                sorting.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _sortingService.Add(sorting);
                TempData["success"] = "Sorting created successfully";
                return RedirectToAction("Index");
            }
            return View(sorting);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var sorting = _sortingService.GetFirstOrDefault(Id, includeProperties: "Harvest,User");
            //var test = _harvestService.GetFirstOrDefault(sorting.HarvestId, includeProperties: "Product,User").Product.Name;
            IEnumerable<SelectListItem> ProductList = _harvestService.GetAll("Product,User")
                .Select(x => new SelectListItem
                {
                    Text = x.Product.Name,
                    Value = x.Product.Id.ToString()
                });
            ViewBag.ProductList = ProductList;
            if (sorting == null)
            {
                return NotFound();
            }
            return View(sorting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SortingViewModel sorting)
        {
            if (ModelState.IsValid)
            {
                sorting.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _sortingService.Update(sorting);
                TempData["success"] = "Sorting edit successfully";
                return RedirectToAction("Index");
            }
            return View(sorting);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var sorting = _sortingService.GetFirstOrDefault(Id, includeProperties: "Harvest,User");
            IEnumerable<SelectListItem> ProductList = _harvestService.GetAll("Product,User")
               .Select(x => new SelectListItem
               {
                   Text = x.Product.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.ProductList = ProductList;
            if (sorting == null)
            {
                return NotFound();
            }
            return View(sorting);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            _sortingService.Delete(Id);
            TempData["success"] = "Sorting delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
