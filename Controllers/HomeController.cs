using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bacon_desktop.Models;

namespace bacon_desktop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult inicio() 
        {
            return View("Contact");
        }

    }
}
