using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace bacon_desktop.Controllers
{
    public class GarzonNotificacionController : Controller
    {
        public IActionResult NotificacionesGarzon()
        {


            Electron.IpcMain.On("async-de-garzon-notify", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonNotificacionService garzonNotificacionService = new GarzonNotificacionService();

                try
                {

                    List<Notificacion> notificacionsDe = garzonNotificacionService.getNotificacionDeGarzon();

                    garzonNotificacionService = null;

                    garzonNotificacionService = new GarzonNotificacionService();

                    List<Notificacion> notificacionsPara = garzonNotificacionService.getNotificacionParaGarzon();

                    List<Notificacion> notificacions = garzonNotificacionService.obtenerTodasNotificacionesOrdenFechaGarzon(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-garzon-notify", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-garzon-notify", ex.Message);
                }
            });

            //    //Cambiar el estado de las notificaciones a leido
            Electron.IpcMain.On("async-garzon-notify-leido", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonNotificacionService garzonNotificacionService = new GarzonNotificacionService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = garzonNotificacionService.cambiarEstadoNotificacionGarzon(idNotificacion);

                    if (result == 1)
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Exito", "Notificación marcada como leída")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };

                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-garzon-notify-leido", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-garzon-notify-leido", ex.Message);
                }
            });


            return View();
        }
    }
}