using Business_Layer.Services.NewsServices;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SkinCare_Product_Sale.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: /News
        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("Role");
            ViewBag.UserRole = role;

                var newsList = await _newsService.GetAllNewsAsync();
                return View(newsList);
           
        }


        // GET: /News/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
                return NotFound();
            return View(news);
        }



        // GET: /News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.AddNewsAsync(news);
                return RedirectToAction(nameof(Index), "News");
            }
            return View(news);
        }

        // GET: /News/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
                return NotFound();
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(News news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.UpdateNewsAsync(news);
                return RedirectToAction(nameof(Index), "News");
            }
            return RedirectToAction(nameof(Index), "News");
        }

        // GET: /News/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.RemoveNewsAsync(id);
            return RedirectToAction(nameof(Index), "News");
        }
    }
}
