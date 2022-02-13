using FruitsTraceabilitySystem.Application.Interfaces.Harvests;
using FruitsTraceabilitySystem.Application.Interfaces.Products;
using FruitsTraceabilitySystem.Application.ViewModels.Harvests;
using FruitsTraceabilitySystem.Domain.Models.SeedRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace FruitsTraceabilitySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SeedRole.RoleAdmin)]
    public class HarvestController : Controller
    {
        #region Properties
        private readonly IHarvestService _harvestService;
        private readonly IProductService _productService;

        #endregion

        #region Constructors
        public HarvestController(IHarvestService harvestService, IProductService productService)
        {
            _harvestService = harvestService ?? throw new ArgumentNullException(nameof(harvestService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<HarvestViewModel> harvests = _harvestService.GetAll(includeProperties: "Product,User");
            return View(harvests);
        }
        public IActionResult Created()
        {
            IEnumerable<SelectListItem> ProductList = _productService.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.ProductList = ProductList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(HarvestViewModel harvest)
        {
            if (ModelState.IsValid)
            {
                harvest.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _harvestService.Add(harvest);
                TempData["success"] = "Harvest created successfully";
                return RedirectToAction("Index");
            }
            return View(harvest);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var harvest = _harvestService.GetFirstOrDefault(Id, includeProperties: "Product,User");
            IEnumerable<SelectListItem> ProductList = _productService.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            ViewBag.ProductList = ProductList;
            if (harvest == null)
            {
                return NotFound();
            }
            return View(harvest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HarvestViewModel harvest)
        {
            if (ModelState.IsValid)
            {
                harvest.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _harvestService.Update(harvest);
                TempData["success"] = "Harvest edit successfully";
                return RedirectToAction("Index");
            }
            return View(harvest);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var harvest = _harvestService.GetFirstOrDefault(Id, includeProperties: "Product,User");
            IEnumerable<SelectListItem> ProductList = _productService.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.ProductList = ProductList;
            if (harvest == null)
            {
                return NotFound();
            }
            return View(harvest);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            _harvestService.Delete(Id);
            TempData["success"] = "Harvest delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
