using Business_Layer.Services.OrderServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using SkinCare_Product_Sale.Extensions;

namespace SkinCare_Product_Sale.Controllers
{
    public class PaymentController : Controller
    {
        private readonly VNPayExtensions _vnpayHelper;
        private readonly IOrderService _orderService;
        public PaymentController(IConfiguration config, IOrderService orderService)
        {
            _vnpayHelper = new VNPayExtensions(config);
            _orderService = orderService;
        }

        public async Task<IActionResult> VnpayCheckout(decimal totalAmount)
        {
            var cartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            var userId = HttpContext.Session.GetInt32("UserId");
            var order = new Order
            {
                AccountId = userId,
                OrderDate = DateTime.Now,
                Status = "Chưa thanh toán",
                OrderDetails = new List<OrderDetail>(),
                Payments = new List<Payment>()
            };
            foreach (var item in cartItems)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Quantity * item?.Product?.Price ?? 0,
                });
            }
            await _orderService.AddOrderAsync(order);
            string paymentUrl = _vnpayHelper.CreatePaymentUrl(HttpContext, totalAmount, order.OrderId.ToString());
            return Redirect(paymentUrl);
        }
        public async Task<IActionResult> VnpayPayNow(decimal totalAmount, string productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var order = new Order
            {
                AccountId = userId,
                OrderDate = DateTime.Now,
                Status = "Chưa thanh toán",
                OrderDetails = new List<OrderDetail>(),
                Payments = new List<Payment>()
            };
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductId = productId,
                    Quantity = 1,
                    Price = totalAmount,
                });
            await _orderService.AddOrderAsync(order);
            string paymentUrl = _vnpayHelper.CreatePaymentUrl(HttpContext, totalAmount, order.OrderId.ToString());
            return Redirect(paymentUrl);
        }
    }
}
