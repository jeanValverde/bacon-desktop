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
        public IActionResult IndexGarzon()
        {
            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-ordenes-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();
                try
                {
                    List<OrdenGarzon> ordenesGarzon = garzonService.listarOrdenesListarParaServir();

                    garzonService = null;
                    garzonService = new GarzonService();

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ordenes-garzon", garzonService.servirOrden(ordenesGarzon));
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ordenes-garzon", ex.Message);
                }
            });


            //CARGAR LAS RECETAS DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-grupo-recetas-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                GarzonService garzonService = new GarzonService();

                try
                {
                    List<OrdenGarzon> ordenesGarzon = garzonService.listarOrdenesListarParaServir();

                    garzonService = null;
                    garzonService = new GarzonService();
                    List<OrdenGarzon> ordenes = garzonService.servirOrden(ordenesGarzon);

                    List<RecetaCantidad> recetaCantidad = garzonService.obtenerRecetasWithCantidad(ordenes);


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-grupo-recetas-garzon", recetaCantidad);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-grupo-recetas-garzon", ex.Message);
                }
            });

            //completar la orden 
            Electron.IpcMain.On("async-receta-servirOrden-garzon", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();


                GarzonService garzonService = new GarzonService();

                try
                {

                    int idOrden = int.Parse(args.ToString());

                    int result = garzonService.servirOrden(idOrden);

                    if (result == 1)
                    {
                        garzonService = null;

                        garzonService = new GarzonService();

                        Notificacion notificacion = new Notificacion();

                        notificacion.Descripcion = $"La orden Número: {args.ToString()} esta lista para llevar a mesa.";

                        notificacion.Asunto = "Cocina: Orden Lista Para Servir";

                        Rol rol = new Rol();

                        rol.Id_rol = 4;

                        notificacion.Rol = rol;

                        int resultNotificacion = garzonService.insertarNotificacion(notificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-servirOrden-garzon", "listo");

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-servirOrden", ex.Message);
                }
            });
            //fin completar la orden

            //cargar el modal 
            Electron.IpcMain.On("modalReceta-window-garzon", async (argument) =>
            {
                //carga el puerto disponible
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/garzon/modalrecetagarzon?idReceta={argument}";

                var optionsWindows = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(optionsWindows, viewPath);
            });

            Electron.IpcMain.On("modalAnular-window-garzon", async (argument) =>
            {
                //carga el puerto disponible
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/garzon/ModalAnularGarzon?idOrden={argument}";

                var optionsWindows = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(optionsWindows, viewPath);
            });
            //cargar un modal 
            return View();
        }

        public IActionResult AnularOrden(string idOrden,String motivo)
        {

            GarzonService garzonService = new GarzonService();
            Int32 ordenID = Int32.Parse(idOrden);

            Orden orden = garzonService.getOrdenById(ordenID);
            garzonService = null;
            garzonService = new GarzonService();
            garzonService.anularOrden(ordenID, motivo);
            garzonService = null;
            garzonService = new GarzonService();
            Notificacion notificacion = new Notificacion();
            Rol rol = new Rol();
            rol.Id_rol = 3;
            notificacion.Rol = rol;
            notificacion.Descripcion = "Anulación de orden N° " + idOrden + " fue anulada";
            notificacion.Asunto = "Finanzas: Orden Anulada";
            String respuesta = "";
            if (garzonService.insertarNotificacion(notificacion)==1)
            {
                garzonService = null;
                garzonService = new GarzonService();
                notificacion = new Notificacion();
                rol = new Rol();
                respuesta = "Se anuló la orden N° "+ ordenID+"\n";
                respuesta += "#Se nofiticó a finanzas \n";
                if (orden.TipoOrden == 0)
                {
                    rol.Id_rol = 5;
                    notificacion.Rol = rol;
                    notificacion.Descripcion = "Anulacion de orden N° " + idOrden + " fue anulada";
                    notificacion.Asunto = "Cocina: Orden Anulada";
                    respuesta += "#Se notificó a cocina";
                }
                if (orden.TipoOrden == 1)
                {
                    rol.Id_rol = 6;
                    notificacion.Rol = rol;
                    notificacion.Descripcion = "Anulacion de orden N° " + idOrden + " fue anulada";
                    notificacion.Asunto = "Bar: Orden Anulada";
                    respuesta += "#Se notificó a bar";
                }
                garzonService.insertarNotificacion(notificacion);

                var options = new NotificationOptions("Exito", "Notificación marcada como leída")
                {
                    OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                    Icon = "/images/cerdito.png"
                };

                Electron.Notification.Show(options);
            }

            ViewData["orden"] = orden;
            ViewData["respuesta"] = respuesta;
            System.Console.WriteLine(idOrden);
            return View("ModalAnularGarzon");
        }





        public IActionResult ModalRecetaGarzon(string idReceta)
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

        public IActionResult ModalAnularGarzon(string idOrden,String respuesta)
        {

            Orden orden = new Orden();


            CocinaService cocinaService = new CocinaService();

            Int32 ordenID = 0;

            try
            {
                ordenID = Int32.Parse(idOrden);
                orden.IdOrden = ordenID;
            }
            catch (Exception)
            {
                
                ordenID = 121;
            }

            if (respuesta == null || respuesta == "")
            {
                ViewData["respuesta"] = respuesta;
            }


            ViewData["orden"] = orden;

            return View();
        }












        public IActionResult NotificacionGarzon()
        {
            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-de-cocina-notify-garzon", (args) =>
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


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-garzon-notify", notificacions);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-de-garzon-notify", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-garzon-notify-leido", (args) =>
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