using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using Microsoft.AspNetCore.Mvc;

namespace bacon_desktop.Controllers
{
    public class DeshabilitarRecetaController : Controller
    {
        public IActionResult Index()
        {
            //CARGAR LAS RECETAS DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-DeshabilitarReceta", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                DeshabilitarRecetaService recetaService = new DeshabilitarRecetaService();

                try
                {
                    List<Receta> recetas = recetaService.listarRecetas();

                    recetaService = null;

                    recetaService = new DeshabilitarRecetaService();

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-DeshabilitarReceta", recetas);


                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-DeshabilitarReceta", ex.Message);
                }
            });


            return View();
        }
    }
}