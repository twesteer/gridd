using gridd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gridd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StartPage()
        {
            return View();
        }

        public IActionResult WaitPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ActualPage()
        {
            return View();
        }

        public IActionResult NewsPage()
        {
            return View();
        }

        public IActionResult ProfilePage()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult RegistrationPage()
        {
            return View();
        }
    }
}