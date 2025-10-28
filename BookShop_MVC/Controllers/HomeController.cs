using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.Services;
using BookShop_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShop_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly IBookService bookService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            categoryService = new CategoryService();
            bookService = new BookService();
        }

        public IActionResult Index()
        {
            CategoryBookViewModel model = new CategoryBookViewModel()
            {
                Books = bookService.GetBooks(),
                Category = categoryService.GetCategory()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
