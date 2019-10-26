using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bacon_desktop.Models;
using ElectronNET.API;
using bacon_desktop.Service;
using BCrypt.Net;

namespace bacon_desktop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["error"] = false;

            ViewData["url"] = "/Home/Panel";


            return View();
        }

        public IActionResult Panel(string username, string password)
        {


            PersonalService personalService = new PersonalService();

            ViewData["error"] = true;

            ViewData["url"] = "../Home/Panel";

            Personal p = personalService.getPersonalByRut(username);

            //rut oka 
            if (p.Rut_personal != null || p.Rut_personal != "")
            {

                //contraseña 
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());


                bool verificado = BCrypt.Net.BCrypt.Verify(password, p.Contrasena_personal);


                if (verificado)
                {

                    //falta arrancar la sesión 

                    ViewData["personal"] = p;

                    return View("Panel");
                }
                else
                {

                    return View("Index");
                }


            }

            return View("Index");
        }



    }
}
