using Business_Layer.Services.AccountServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SkinCare_Product_Sale.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAccountService _accountService;

        public ProfileController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");
            var account = await _accountService.FindByUsernameAsync(username);

            if (account == null)
                return NotFound();

            var customer = account.Customers.First();

            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null) return RedirectToAction("Login", "Auth");

            var account = await _accountService.FindByUsernameAsync(username);
            if (account == null) return NotFound();

            if (account.Password != CurrentPassword)
            {
                TempData["Error"] = "Mật khẩu hiện tại không đúng.";
                return RedirectToAction("Index", "Profile");
            }

            if (NewPassword != ConfirmPassword)
            {
                TempData["Error"] = "Mật khẩu xác nhận không khớp.";
                return RedirectToAction("Index", "Profile");
            }

            account.Password = NewPassword;
            await _accountService.UpdateAsync(account);

            TempData["Success"] = "Cập nhật mật khẩu thành công.";
            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(Customer model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Thông tin không hợp lệ.";
                return View("Profile", model);
            }

            var customer = await _accountService.FindCustomerByIdAsync((int)userId);

            if (customer == null)
            {
                TempData["Error"] = "Không tìm thấy khách hàng.";
                return RedirectToAction("Profile");
            }

            customer.FullName = model.FullName;
            customer.Email = model.Email;
            customer.Phone = model.Phone;


            await _accountService.UpdateCustomerAsync(customer);
            TempData["Success"] = "Cập nhật thông tin thành công!";

            return RedirectToAction("Index", "Profile");
        }

    }
}
