using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Product;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var product = _productService.GetAll();
            return View(product);
        }
        public IActionResult DisplayProducts()
        {
            var product = _productService.GetAll();
            return View(product);
        }
        public IActionResult Create()
        {
            var category = _categoryService.GetAll();
            ViewData["Categories"] = new SelectList(category.Data, "Id", "Name");
            return View();

        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequestModel createProduct)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createproducts = _productService.Create(createProduct, int.Parse(user));
            if (createproducts.Status == false)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var get = _productService.GetById(id);
            return View(get);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductUpdateRequestModel productUpdateReqestModel,int id)
        {
            _productService.Update(productUpdateReqestModel, id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var get = _productService.GetById(id);
            return View(get);
        }
    }
}
