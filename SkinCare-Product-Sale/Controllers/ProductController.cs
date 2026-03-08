using Business_Layer.Services.CategoryServices;
using Business_Layer.Services.FeedbackServices;
using Business_Layer.Services.ImagesServices;
using Business_Layer.Services.ProductServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace SkinCare_Product_Sale.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IImagesService _imagesService;
        private readonly IFeedbackService _feedbackService;

        public ProductController(IProductService productService, ICategoryService categoryService, IImagesService imagesService, IFeedbackService feedbackService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _imagesService = imagesService;
            _feedbackService = feedbackService;
        }

        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Manager" || role == "Staff")
            {
                var products = await _productService.GetAllProductsAsync();
                return View(products);
            } else
            {
                return RedirectToAction("Index","Home");
            }
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, List<string> ImageUrls)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = Guid.NewGuid().ToString("N");
                await _productService.AddProductAsync(product);
                foreach (var url in ImageUrls.Where(u => !string.IsNullOrEmpty(u)).Take(2))
                {
                    var image = new Image
                    {
                        ProductId = product.ProductId,
                        ImageUrl = url
                    };
                    await _imagesService.SaveImagesAsync(image);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName");
            return View(product);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddFeedback(Feedback feedback)
        {
            if (feedback.Content.IsNullOrEmpty())
            {
                TempData["FeedbackError"] = "Vui lòng điền thông tin phản hồi";
                return RedirectToAction("Details", new { id = feedback.ProductId });
            }

            try
            {
                feedback.AccountId = HttpContext.Session.GetInt32("UserId");
                await _feedbackService.AddFeedbackAsync(feedback);
                TempData["FeedbackSuccess"] = "Gửi phản hồi thành công! Cảm ơn bạn đã đóng góp ý kiến.";
            }
            catch (Exception ex)
            {
                TempData["FeedbackError"] = "Có lỗi xảy ra khi gửi phản hồi. Vui lòng thử lại!";
                Console.WriteLine($"Error: {ex.Message}");
            }

            return RedirectToAction("Details", new { id = feedback.ProductId });
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Product product)
        {
            if (id != product.ProductId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateProductAsync(product);
                    return RedirectToAction("Index", "Product");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Lỗi khi cập nhật sản phẩm: " + ex.Message);
                }
            }

            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(String id)
        {
            await _productService.ToggleStatusAsync(id);
            return RedirectToAction("Index");
        }


    }
}
