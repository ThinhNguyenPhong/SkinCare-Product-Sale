using Business_Layer.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace SkinCare_Product_Sale.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderHistoryController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) 
            {
                return RedirectToAction("Login", "Auth");
            }
            var orderHistory = await _orderService.GetOrdersByUserIdAsync((int)userId);
            return View(orderHistory);
        }

        public async Task<IActionResult> CustomerOrders(int customerId)
        {
            var orderHistory = await _orderService.GetOrdersByUserIdAsync(customerId);
            ViewBag.CustomerId = customerId;
            return View(orderHistory);
        }
    }
}
