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
        public IActionResult IndexBar()
        {
            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-receta-bar", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {
                    List<OrdenBar> ordenesBar = barService.getOrdenesByEstadoEnBar();

                    barService = null;

                    barService = new BarService();


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-bar", barService.completarOrdenBar(ordenesBar));
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-bar", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-receta-cantidad-bar", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {
                    List<OrdenBar> ordenesBar = barService.getOrdenesByEstadoEnBar();

                    barService = null;

                    barService = new BarService();

                    List<OrdenBar> ordenes = barService.completarOrdenBar(ordenesBar);

                    List<RecetaCantidad> recetaCantidad = barService.obtenerRecetasWithCantidadBar(ordenes);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-cantidad-bar", recetaCantidad);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-cantidad-bar", ex.Message);
                }
            });

            //completar la orden 
            Electron.IpcMain.On("async-receta-completarOrden-bar", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                BarService barService = new BarService();

                try
                {

                    int idOrden = int.Parse(args.ToString());

                    int result = barService.completarOrdenBar(idOrden);

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

                        int resultNotificacion = barService.insertarNotificacionBar(notificacion);

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-completarOrden-bar", "listo");

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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-completarOrden-bar", ex.Message);
                }
            });
            //fin completar la orden




            //cargar el modal 
            Electron.IpcMain.On("modalRecetaBar-window", async (argument) =>
            {
                //carga el puerto disponible
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/bar/modalrecetaBar?idReceta={argument}";

                var optionsWindows = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(optionsWindows, viewPath);
            });
            //cargar un modal 



            return View();
        }

        public IActionResult ModalRecetaBar(string idReceta)
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

            receta = barService.getRecetaByIdBar(recetaID);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            barService = null;

            barService = new BarService();

            ingredientes = barService.getIngredientesByIdRecetaBar(receta.IdReceta);

            ViewData["DatosB"] = recetaID;
            ViewData["recetaB"] = receta;
            ViewData["ingredientesB"] = ingredientes;

            return View();
        }


       
           


            
        
    }
}



    