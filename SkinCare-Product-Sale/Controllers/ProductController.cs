using Business_Layer.Services.CategoryServices;
using Business_Layer.Services.ProductServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SkinCare_Product_Sale.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = Guid.NewGuid().ToString("N");
                await _productService.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
