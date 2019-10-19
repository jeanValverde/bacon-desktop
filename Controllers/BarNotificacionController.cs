using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bacon_desktop.Controllers
{
    public class BarNotificacionController : Controller
{
        public IActionResult Index()
        {

            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-BarNotificacion-notify", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarNotificacionService barNotificacionService = new BarNotificacionService();

                try
                {

                    List<Notificacion> notificacionsDe = barNotificacionService.getNotificacionDeBar();

                    barNotificacionService = null;

                    barNotificacionService = new BarNotificacionService();

                    List<Notificacion> notificacionsPara = barNotificacionService.getNotificacionParaBar();

                    List<Notificacion> notificacions = barNotificacionService.obtenerTodasNotificacionesOrdenFecha(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-BarNotificacion-notify", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-BarNotificacion-notify", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-BarNotificacion-notify-leido", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarNotificacionService barNotificacionService = new BarNotificacionService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = barNotificacionService.cambiarEstadoNotificacion(idNotificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-BarNotificacion-notify-leido", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-BarNotificacion-notify-leido", ex.Message);
                }
            });


            return View();
        }



    }
}
