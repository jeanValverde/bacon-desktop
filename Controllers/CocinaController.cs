using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace bacon_desktop.Controllers
{
    public class CocinaController : Controller
    {
        public IActionResult Index()
        {

            Electron.IpcMain.On("async-msg", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PersonalService personalService = new PersonalService();
                try
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply", personalService.update(124, 1 , 1, 1));
                }
                catch (Exception ex)
                {
                    List<Personal> peronales = new List<Personal>();

                    Personal personal = new Personal();

                    personal.Nombres_personal = "error: " + ex.Message;

                    peronales.Add(personal);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply", peronales);
                }
            });

            return View();
        }

        
        
    }
}