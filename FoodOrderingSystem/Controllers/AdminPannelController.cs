using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Context
{
    public class AdminPannelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Analytics()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult OrderList()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            return View();
        }

        public IActionResult EcomProductDetail()
        {
            return View();
        }


    }
}
