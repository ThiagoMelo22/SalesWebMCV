using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesWebMcv.Models;
using SalesWebMcv.Services;

namespace SalesWebMcv.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _department;

        public SellersController(SellerService sellerService, DepartmentService department) 
        {
            _sellerService = sellerService;
            _department = department;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() 
        {
            var departments = _department.FindAll();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) 
        {
            if (ModelState.IsValid) 
            {
                _sellerService.Insert(seller);
                return RedirectToAction(nameof(Index));
            }

            var departments = _department.FindAll();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", seller.DepartmentId);
            return View(seller);
        }
    }
}
