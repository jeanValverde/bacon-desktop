using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using ElectronNET.API.Entities;
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

                    
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-DeshabilitarReceta", recetas);

                    


                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-DeshabilitarReceta", ex.Message);
                }
            });



            Electron.IpcMain.On("async-DeshabilitarRece", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                DeshabilitarRecetaService recetaService = new DeshabilitarRecetaService();

                try
                {

                    int idReceta = int.Parse(args.ToString());

                    int result = recetaService.deshabilitarDisponibilidad(idReceta);

                    if (result == 1)
                    {

                        var options = new NotificationOptions("Exito", "Disponibilidad Cambiada")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("")
                        };

                        Electron.Notification.Show(options);

                    }
                    else
                    {
                        var options = new NotificationOptions("Error", "Disponibilidad No Cambiada")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("")
                        };

                        Electron.Notification.Show(options);
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-DeshabilitarRece", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-DeshabilitarRece", ex.Message);
                }
            });


            return View();
        }
    }
}