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
    public class HabilitarRecetaController : Controller
    {
        public IActionResult Index()
        {
            //CARGAR LAS RECETAS DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-HabilitarReceta", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                
                Console.Write("hola");

                HabilitarRecetaService recetaService = new HabilitarRecetaService();

                try
                {
                    
                    List<Receta> recetasHab = recetaService.listarRecetasHab();

                    recetaService = null;


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-HabilitarReceta", recetasHab);




                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-HabilitarReceta", ex.Message);
                }
            });



            Electron.IpcMain.On("async-HabilitarRece", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                HabilitarRecetaService recetaService = new HabilitarRecetaService();

                try
                {

                    int idReceta = int.Parse(args.ToString());

                    int result = recetaService.habilitarDisponibilidad(idReceta);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-HabilitarRece", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-HabilitarRece", ex.Message);
                }
            });


            return View();
        }
    }
}