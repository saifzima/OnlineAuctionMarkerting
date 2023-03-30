using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Inplementation.Service;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models.DTO.Category;

namespace OlineAuctionMarketing.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var auctioneers = _categoryService.GetAll();
            return View(auctioneers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryRequestModel categoryRequestModel)
        {
            _categoryService.Create(categoryRequestModel);
            return RedirectToAction("Login", "User");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var get = _categoryService.GetById(id);
            return View(get);
        }
        public IActionResult Edit(int id)
        {
            var get = _categoryService.GetById(id);
            return View(get);
        }

        [HttpPost]
        public IActionResult Edit(CategoryResponseModel categoryUpdateRequestModel, int id)
        {
            _categoryService.Update(categoryUpdateRequestModel, id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var get = _categoryService.GetById(id);
            return View(get);
        }
        public IActionResult GetAllCategories()
        {
            var list = _categoryService.GetAll();
            return View(list);
        }
    }
}
