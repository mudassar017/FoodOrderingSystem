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
    }
}
