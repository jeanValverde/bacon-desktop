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
    public class GarzonController : Controller
    {
        public IActionResult NotificacionGarzon()
        {

                //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
                Electron.IpcMain.On("async-de-bar-notify-garzon", (args) =>
                {
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();

                    GarzonService garzonService = new GarzonService();

                    try
                    {

                        List<Notificacion> notificacionsDe = garzonService.getNotificacionDeBarGarzon();

                        garzonService = null;

                        garzonService = new GarzonService();

                        List<Notificacion> notificacionsPara = garzonService.getNotificacionParaBarGarzon();

                        List<Notificacion> notificacions = garzonService.obtenerTodasNotificacionesOrdenFechaBarGarzon(notificacionsDe, notificacionsPara);


                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-bar-notify-garzon", notificacions);

                    }
                    catch (Exception ex)
                    {
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-bar-notify-garzon", ex.Message);
                    }
                });

                //    //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
                Electron.IpcMain.On("async-bar-notify-leido-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = garzonService.cambiarEstadoNotificacionBarGarzon(idNotificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-bar-notify-leido-garzon", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-bar-notify-leido-garzon", ex.Message);
                }
            });





            //Notificaciones de cocina

            Electron.IpcMain.On("async-de-cocina-notify-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();

                try
                {

                    List<Notificacion> notificacionsDe = garzonService.getNotificacionDeCocinaGarzon();

                    garzonService = null;

                    garzonService = new GarzonService();

                    List<Notificacion> notificacionsPara = garzonService.getNotificacionParaCocinaGarzon();

                    List<Notificacion> notificacions = garzonService.obtenerTodasNotificacionesOrdenFechaCocinaGarzon(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-cocina-notify-garzon", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-cocina-notify-garzon", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-cocina-notify-leido-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = garzonService.cambiarEstadoNotificacionCocinaGarzon(idNotificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cocina-notify-leido-garzon", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cocina-notify-leido-garzon", ex.Message);
                }
            });


            //CARGAR LAS NOTIFICACION PARA GARZON  async-Nombre 
            Electron.IpcMain.On("async-de-garzon-notify-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();

                try
                {

                    List<Notificacion> notificacionsDe = garzonService.getNotificacionDeGarzon();

                    garzonService = null;

                    garzonService = new GarzonService();

                    List<Notificacion> notificacionsPara = garzonService.getNotificacionParaGarzon();

                    List<Notificacion> notificacions = garzonService.obtenerTodasNotificacionesOrdenFechaGarzonEnviadas(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-garzon-notify-garzon", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-garzon-notify-garzon", ex.Message);
                }
            });

            //    //CARGAR LAS ORDENES DEL MAIN GARZON  async-Nombre 
            Electron.IpcMain.On("async-garzon-notify-leido-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = garzonService.cambiarEstadoNotificacionGarzonEnviadas(idNotificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-garzon-notify-leido-garzon", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-garzon-notify-leido-garzon", ex.Message);
                }
            });


            return View();
        }
    }

}