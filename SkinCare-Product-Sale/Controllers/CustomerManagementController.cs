using Business_Layer.Services.AccountServices;
using Business_Layer.Services.OrderServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SkinCare_Product_Sale.Controllers
{
    public class CustomerManagementController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;

        public CustomerManagementController(IAccountService accountService, IOrderService orderService)
        {
            _accountService = accountService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Manager" || role == "Staff")
            {
                var customers = await _accountService.GetAllCustomersAsync();

                return View(customers);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            var existingCustomer = await _accountService.FindCustomerByIdAsync((int)customer.AccountId);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.FullName = customer.FullName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;

            await _accountService.UpdateCustomerAsync(existingCustomer);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _accountService.FindCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _accountService.DeleteCustomerAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var result = await _accountService.ToggleAccountStatus(id);
            if (!result)
                return NotFound();

            return RedirectToAction("Index"); // Redirect to account list
        }



    }
}
