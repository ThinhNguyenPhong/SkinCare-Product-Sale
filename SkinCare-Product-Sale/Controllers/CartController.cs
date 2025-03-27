using Business_Layer.Services.ProductServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using SkinCare_Product_Sale.Extensions;

namespace SkinCare_Product_Sale.Controllers
{
    public class CartController : Controller
{
    private readonly IProductService _productService;

    public CartController(IProductService productService)
    {
            _productService = productService;
    }

    // Hiển thị giỏ hàng
    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        ViewBag.TotalPrice = cart.Sum(item => item.Product.Price * item.Quantity);
        return View(cart);
    }

    // Thêm sản phẩm vào giỏ hàng
    public async Task<IActionResult> Add(String productId, int quantity = 1)
    {
            var product = await _productService.GetProductByIdAsync(productId);
        if (product == null)
        {
            return NotFound();
        }

        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        var existingItem = cart.FirstOrDefault(p => p.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Product = product,
                    Quantity = quantity
                });
        }

        HttpContext.Session.SetObjectAsJson("Cart", cart);
        return RedirectToAction("Index");
    }

    // Xóa sản phẩm
    public IActionResult Remove(String id)
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        cart.RemoveAll(p => p.ProductId == id);
        HttpContext.Session.SetObjectAsJson("Cart", cart);
        return RedirectToAction("Index");
    }

        // Cập nhật số lượng
        [HttpPost]
        public IActionResult UpdateQuantity(string id, int quantity, string action)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            var item = cart.FirstOrDefault(p => p.ProductId == id);

            if (item != null)
            {
                if (action == "increase")
                {
                    item.Quantity++;
                }
                else if (action == "decrease")
                {
                    if (item.Quantity > 1)
                        item.Quantity--;
                }
                else
                {
                    item.Quantity = quantity < 1 ? 1 : quantity;
                }

                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

    }

}
