using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesWebMcv.Models;
using SalesWebMcv.Models.ViewModels;
using SalesWebMcv.Services;
using SalesWebMcv.Services.Exceptions;

namespace SalesWebMcv.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService department) 
        {
            _sellerService = sellerService;
            _departmentService = department;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() 
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        public IActionResult Details(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) 
            {
                return NotFound();
            }

            return View(obj);
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

            var departments = _departmentService.FindAll();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", seller.DepartmentId);
            return View(seller);
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var seller = _sellerService.FindById(id.Value);
            if (seller == null) 
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) 
        {
            if (id != seller.Id) 
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (DbConcurrencyException dbEx)
            {
                return BadRequest();
            }
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) 
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
