using Business_Layer.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Data_Access_Layer.Requests;
namespace SkinCare_Product_Sale.Controllers
{
    public class StaffManagementController : Controller
    {   
        private readonly IAccountService _accountService;
        public StaffManagementController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Manager")
            {
                var customers = await _accountService.GetAllStaffAsync();

                return View(customers);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var result = await _accountService.ToggleAccountStatus(id);
            if (!result)
                return NotFound();

            return RedirectToAction("Index"); // Redirect to account list
        }

        [HttpPost("AddStaff")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStaff([FromBody] AddStaffRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Vui lòng nhập đầy đủ thông tin.");
            }

            var result = await _accountService.AddStaffAsync(request.Username, request.Password);

            if (result)
            {
                return Ok(new { message = "Thêm nhân viên thành công" });
            }

            return BadRequest("Không thể thêm nhân viên. Có thể username đã tồn tại.");
        }
    }
}
