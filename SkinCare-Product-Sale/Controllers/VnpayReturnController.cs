using Business_Layer.Services.OrderServices;
using Business_Layer.Services.PaymentServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SkinCare_Product_Sale.Controllers
{
    public class VnpayReturnController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        public VnpayReturnController(IPaymentService paymentService, IOrderService orderService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = HttpContext.Request.Query;

            string vnp_TxnRef = query["vnp_TxnRef"];
            string vnp_Amount = query["vnp_Amount"];
            string vnp_OrderInfo = query["vnp_OrderInfo"];
            string vnp_ResponseCode = query["vnp_ResponseCode"];
            string vnp_TransactionNo = query["vnp_TransactionNo"];
            string vnp_PayDate = query["vnp_PayDate"];
            string vnp_BankCode = query["vnp_BankCode"];
            string vnp_TransactionStatus = query["vnp_TransactionStatus"];

            decimal amount = decimal.Parse(vnp_Amount) / 100;

            bool isSuccess = vnp_ResponseCode == "00" && vnp_TransactionStatus == "00";

            ViewBag.OrderId = vnp_TxnRef;
            ViewBag.Amount = amount.ToString("N0") + " đ";
            ViewBag.OrderInfo = vnp_OrderInfo;
            ViewBag.TransactionNo = vnp_TransactionNo;
            ViewBag.PayDate = vnp_PayDate;
            ViewBag.BankCode = vnp_BankCode;
            ViewBag.IsSuccess = isSuccess;
            await _paymentService.AddPaymentAsync(new Payment()
            {
                OrderId = int.Parse(vnp_OrderInfo),
                PaymentMethod = "Thanh toán online",
                PaymentDate = DateTime.Now,
            });
            if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
            {
                Order order = await _orderService.GetOrderByIdAsync(int.Parse(vnp_OrderInfo));
                order.Status = "Đã thanh toán";
                await _orderService.UpdateOrderAsync(order);
            }
            HttpContext.Session.Remove("Cart");
            return View();
        }
    }
}
