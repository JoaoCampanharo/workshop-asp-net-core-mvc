using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService __sellerService;

        public SellersController(SellerService sellerService)
        {
            __sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = __sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            __sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}