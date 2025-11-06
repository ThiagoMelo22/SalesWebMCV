using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMcv.Models;
using SalesWebMcv.Models.ViewModels;

namespace SalesWebMcv.Controllers
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

        public IActionResult About() {
            ViewData["Message"] = "Sales wbe MVC App from C# Course";
            ViewData["Aluno"] = "Thiago Melo";
            return View();
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
