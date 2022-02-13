using FruitsTraceabilitySystem.Application.Interfaces.Categories;
using FruitsTraceabilitySystem.Application.Interfaces.Products;
using FruitsTraceabilitySystem.Application.ViewModels.Products;
using FruitsTraceabilitySystem.Domain.Models.SeedRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FruitsTraceabilitySystem.Web.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SeedRole.RoleAdmin)]
    public class ProductController : Controller
    {
        #region Properties
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<ProductViewModel> products = _productService.GetAll(includeProperties: "Category");
            return View(products);
        }
        public IActionResult Created()
        {
            IEnumerable<SelectListItem> CategoryList = _categoryService.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            ViewBag.CategoryList = CategoryList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var product = _productService.GetFirstOrDefault(Id, includeProperties: "Category");
            IEnumerable<SelectListItem> CategoryList = _categoryService.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.CategoryList = CategoryList;
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData["success"] = "Product edit successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var product = _productService.GetFirstOrDefault(Id, includeProperties: "Category");
            IEnumerable<SelectListItem> CategoryList = _categoryService.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.Id.ToString()
               });
            ViewBag.CategoryList = CategoryList;
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            _productService.Delete(Id);
            TempData["success"] = "Product delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
