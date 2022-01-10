using auktioner.ViewModels;
using auktioner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace auktioner.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoriesRepository;

        private AppDbContext _appDbContext;

        public CategoryController(ICategoryRepository categoriesRepository, AppDbContext appDbContext)
        {
            _categoriesRepository = categoriesRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult AddCategory()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            addCategoryViewModel.Categories = _categoriesRepository.AllCategories;
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Add(category);
                _appDbContext.SaveChanges();
                return RedirectToAction("AddCategory");
            }
            return View(category);
        }
    }
}
