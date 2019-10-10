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
    public class CocinaController : Controller
    {
        public IActionResult Index()
        {
            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-receta", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CocinaService cocinaService = new CocinaService();

                try
                {
                    List<OrdenCocina> ordenesCocina = cocinaService.getOrdenesByEstadoEnCocina();

                    cocinaService = null;

                    cocinaService = new CocinaService();


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta", cocinaService.completarOrden(ordenesCocina));
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

                CocinaService cocinaService = new CocinaService();

                try
                {
                    List<OrdenCocina> ordenesCocina = cocinaService.getOrdenesByEstadoEnCocina();

                    cocinaService = null;

                    cocinaService = new CocinaService();

                    List<OrdenCocina> ordenes = cocinaService.completarOrden(ordenesCocina);

                    List<RecetaCantidad> recetaCantidad = cocinaService.obtenerRecetasWithCantidad(ordenes);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-cantidad", recetaCantidad );

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

                CocinaService cocinaService = new CocinaService();

                try
                {

                    int idOrden = int.Parse(args.ToString());

                    int result = cocinaService.completarOrden(idOrden);

                    if (result == 1)
                    {
                        cocinaService = null;

                        cocinaService = new CocinaService();

                        Notificacion notificacion = new Notificacion();

                        notificacion.Descripcion = $"La orden Número: {args.ToString()} esta lista para llevar a mesa.";

                        notificacion.Asunto = "Cocina: Orden Lista Para Servir";

                        Rol rol = new Rol();

                        rol.Id_rol = 4;

                        notificacion.Rol = rol;

                        int resultNotificacion = cocinaService.insertarNotificacion(notificacion);

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
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/cocina/modalreceta?idReceta={argument}";

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

            CocinaService cocinaService = new CocinaService();

            Int32 recetaID = 0;

            try
            {
                recetaID = Int32.Parse(idReceta);
            }
            catch (Exception)
            {
                recetaID = 121;
            }

            receta = cocinaService.getRecetaById(recetaID);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            cocinaService = null;

            cocinaService = new CocinaService();

            ingredientes = cocinaService.getIngredientesByIdReceta(receta.IdReceta);

            ViewData["Datos"] = recetaID;
            ViewData["receta"] = receta;
            ViewData["ingredientes"] = ingredientes;

            return View();
        }


        public IActionResult Notificacion()
        {

            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-de-cocina-notify", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CocinaService cocinaService = new CocinaService();

                try
                {

                    List<Notificacion> notificacionsDe = cocinaService.getNotificacionDeCocina();

                    cocinaService = null;

                    cocinaService = new CocinaService();

                    List<Notificacion> notificacionsPara = cocinaService.getNotificacionParaCocina();

                    List<Notificacion> notificacions = cocinaService.obtenerTodasNotificacionesOrdenFecha(notificacionsDe, notificacionsPara);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-cocina-notify", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-cocina-notify", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-cocina-notify-leido", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CocinaService cocinaService = new CocinaService();

                try
                {
                    int idNotificacion = int.Parse(args.ToString());

                    int result = cocinaService.cambiarEstadoNotificacion(idNotificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cocina-notify-leido", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cocina-notify-leido", ex.Message);
                }
            });


            return View();
        }



    }
}