using Microsoft.AspNetCore.Mvc;

namespace SkinCare_Product_Sale.Controllers
{
    public class ListProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
