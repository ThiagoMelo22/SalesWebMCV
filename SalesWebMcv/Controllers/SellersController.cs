using Microsoft.AspNetCore.Mvc;

namespace SalesWebMcv.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
