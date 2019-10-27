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
    public class PagoNotificacionController : Controller
{
   
    public IActionResult Index()
    {
            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-PagoNotificacion-notify", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagoNotificacionService pagoNotificacionService = new PagoNotificacionService();

                try
                {

                    List<Notificacion> notificacionsDe = pagoNotificacionService.getNotificacionDePago();

                    pagoNotificacionService = null;

                    pagoNotificacionService = new PagoNotificacionService();

                    List<Notificacion> notificacionsPara = pagoNotificacionService.getNotificacionParaPago();

                    List<Notificacion> notificacions = pagoNotificacionService.obtenerTodasNotificacionesOrdenFecha(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-PagoNotificacion-notify", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-PagoNotificacion-notify", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-PagoNotificacion-notify-leido", (args) =>
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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-PagoNotificacion-notify-leido", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-PagoNotificacion-notify-leido", ex.Message);
                }
            });
            return View();
        }
}
}
