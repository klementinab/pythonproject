using FruitsTraceabilitySystem.Application.Interfaces.Categories;
using FruitsTraceabilitySystem.Application.ViewModels.Categories;
using FruitsTraceabilitySystem.Domain.Models.SeedRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitsTraceabilitySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SeedRole.RoleAdmin)]
    public class CategoryController : Controller
    {
        #region Properties
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<CategoryViewModel> categories = _categoryService.GetAll();
            return View(categories);
        }
        public IActionResult Created()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Created(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _categoryService.GetFirstOrDefault(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                TempData["success"] = "Category edit successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _categoryService.GetFirstOrDefault(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            _categoryService.Delete(Id);
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
