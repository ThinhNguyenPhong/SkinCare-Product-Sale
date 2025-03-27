using Business_Layer.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using SkinCare_Product_Sale.Requests;

namespace SkinCare_Product_Sale.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _accountService.RegisterAsync(request);
            if (result)
            {
                return Ok(new { message = "Đăng ký thành công!" });
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _accountService.LoginAsync(request);

            if (result == null)
            {
                return Unauthorized("Đăng nhập thất bại");
            }

            // Prevent login if account is deactivated
            if (!result.IsActive)
            {
                return Unauthorized("Tài khoản của bạn đã bị vô hiệu hóa.");
            }

            HttpContext.Session.SetInt32("UserId", result.AccountId);
            HttpContext.Session.SetString("Username", result.Username);
            HttpContext.Session.SetString("Role", result.RoleName);

            return Ok(new { message = "Đăng nhập thành công" });
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("Username");
                HttpContext.Session.Remove("Role");
            return Ok();
        }
    }
}
