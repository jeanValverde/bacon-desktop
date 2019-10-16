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
    public class BarController : Controller
    {
        public IActionResult IndexBarController()
        {

            //Cargas las ordenes del main
            Electron.IpcMain.On("async-receta", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {
                    List<OrdenBar> ordenesBar = barService.getOrdenesByEstadoEnBar();

                    barService = null;

                    barService = new BarService();

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta", barService.completarOrden(ordenesBar));

                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta", ex.Message);
                }
            });

            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-receta-cantidad", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {
                    List<OrdenBar> ordenesBar = barService.getOrdenesByEstadoEnBar();

                    barService = null;

                    barService = new BarService();

                    List<OrdenBar> ordenes = barService.completarOrden(ordenesBar);

                    List<RecetaCantidad> recetaCantidad = barService.obtenerRecetasWithCantidad(ordenes);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-cantidad", recetaCantidad);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-cantidad", ex.Message);
                }
            });

            //completar la orden 
            Electron.IpcMain.On("async-receta-completarOrden", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {
                    int idOrden = int.Parse(args.ToString());

                    int result = barService.completarOrden(idOrden);

                    if (result == 1)
                    {
                        barService = null;

                        barService = new BarService();

                        Notificacion notificacion = new Notificacion();

                        notificacion.Descripcion = $"La orden Número: {args.ToString()} esta lista para llevar a mesa.";

                        notificacion.Asunto = "Bar: Orden Lista Para Servir";

                        Rol rol = new Rol();

                        rol.Id_rol = 4;

                        notificacion.Rol = rol;

                        int resultNotificacion = barService.insertarNotificacion(notificacion);

                        if (resultNotificacion == 1)
                        {
                            //carga una notificacion 
                            var options = new NotificationOptions("Orden Completa", "La orden Número: " + args + " fue notificada a garzón para llevar a mesa.")
                            {
                                OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("La orden Número: " + args + " fue notificada a garzón para llevar a mesa, Puedes ver los detalles en la opción de notificaciones"),
                                Icon = "~/images/clienteCerdos.png"
                            };

                            Electron.Notification.Show(options);
                            //termina de cargar una notificacion 
                        }

                    }
                    else
                    {
                        throw new Exception();
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-completarOrden", "listo");

                }
                catch (Exception ex)
                {
                    //carga una notificacion 
                    var options = new NotificationOptions("Error", "Algo mal ocurrio")
                    {
                        OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("Sorry"),
                        Icon = "/images/cerdito.png"
                    };

                    Electron.Notification.Show(options);
                    //termina de cargar una notificacion 

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-completarOrden", ex.Message);
                }
            });
            //fin completar la orden


            //cargar el modal 
            Electron.IpcMain.On("modalReceta-window", async (argument) =>
            {
                //carga el puerto disponible
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/bar/modalreceta?idReceta={argument}";

                var optionsWindows = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(optionsWindows, viewPath);
            });
            //cargar un modal 



            return View();
        }

        public IActionResult ModalReceta(string idReceta)
        {

            Receta receta = new Receta();

            BarService barService = new BarService();

            Int32 recetaID = 0;

            try
            {
                recetaID = Int32.Parse(idReceta);
            }
            catch (Exception)
            {
                recetaID = 121;
            }

            receta = barService.getRecetaById(recetaID);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            barService = null;

            barService = new BarService();

            ingredientes = barService.getIngredientesByIdReceta(receta.IdReceta);

            ViewData["Datos"] = recetaID;
            ViewData["receta"] = receta;
            ViewData["ingredientes"] = ingredientes;

            return View();
        }


        public IActionResult Notificacion()
        {

            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-de-bar-notify", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {

                    List<Notificacion> notificacionsDe = barService.getNotificacionDeBar();

                    barService = null;

                    barService = new BarService();

                    List<Notificacion> notificacionsPara = barService.getNotificacionParaBar();

                    List<Notificacion> notificacions = barService.obtenerTodasNotificacionesOrdenFecha(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-bar-notify", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-bar-notify", ex.Message);
                }
            });

            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-bar-notify-leido", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = barService.cambiarEstadoNotificacion(idNotificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-bar-notify-leido", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-bar-notify-leido", ex.Message);
                }
            });

            return View();

        }
    }

}