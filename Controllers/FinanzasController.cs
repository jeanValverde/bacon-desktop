using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bacon_desktop.Controllers
{
    public class FinanzasController : Controller
    {
        public IActionResult IndexCierreCaja()
        {
            return View();
        }
    }
}