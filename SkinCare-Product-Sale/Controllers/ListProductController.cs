using Business_Layer.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Data_Access_Layer.Responses;
namespace SkinCare_Product_Sale.Controllers
{
    public class ListProductController : Controller
    {
        private readonly IProductService _productService;
        public ListProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 12, string sortOrder = "default")
        {
            var products = await _productService.GetAllProductsAsync();

            // Sắp xếp theo giá trị sortOrder
            products = sortOrder switch
            {
                "price_desc" => products.OrderByDescending(p => p.Price).ToList(),
                "price_asc" => products.OrderBy(p => p.Price).ToList(),
                _ => products.OrderBy(p => p.ProductId).ToList(), // mặc định
            };

            int totalProducts = products.Count();
            var pagedProducts = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new ProductListViewModel
            {
                Products = pagedProducts,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize),
                SortOrder = sortOrder
            };

            return View(model);
        }


    }
}
