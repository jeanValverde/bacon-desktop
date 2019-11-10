using System;
using System.Collections.Generic;
using System.Linq;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace bacon_desktop.Controllers
{
    public class PagarOrdenController : Controller
    {
        public IActionResult Index()
        {
            //CARGAR 
            Electron.IpcMain.On("async-pagarOrden-clientes", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {
                    List<Cliente> clientes = pagarOrdenService.getClienteMesa();

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-clientes", clientes);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-clientes", ex.Message);
                }
            });


            //CARGAR 
            Electron.IpcMain.On("async-pagarOrden-clienteDetalle", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {

                    int idCliente = int.Parse(args.ToString()); 

                    Cliente cliente = pagarOrdenService.getClienteApagar(idCliente);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-clienteDetalle", cliente );
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-clienteDetalle", ex.Message);
                }
            });

            //CARGAR 
            Electron.IpcMain.On("async-pagarOrden-totalOrdenClienteDetalle", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {

                    int idCliente = int.Parse(args.ToString());

                    int total = pagarOrdenService.getClienteApagarTotalOrden(idCliente);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-totalOrdenClienteDetalle", total);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-totalOrdenClienteDetalle", ex.Message);
                }
            });

            //CARGAR 
            Electron.IpcMain.On("async-pagarOrden-totalPagarClienteDetalle", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {

                    int idCliente = int.Parse(args.ToString());

                    int total = pagarOrdenService.getClienteTotalApagarOrden(idCliente); 

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-totalPagarClienteDetalle", total);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-totalOrdenClienteDetalle", ex.Message);
                }
            });


            Electron.IpcMain.On("information-dialog-cambiarTotalPagar", async (args) =>
            {
                var options = new MessageBoxOptions("¿Seguro que desea cambiar el valor total a pagar del cliente?")
                {
                    Type = MessageBoxType.info,
                    Title = "Informatión",
                    Buttons = new string[] { "Si" , "No" }
                };

                var result = await Electron.Dialog.ShowMessageBoxAsync(options);

                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                Electron.IpcMain.Send(mainWindow, "information-dialog-reply-cambiarTotalPagar", result.Response);
            });


            //CARGAR 
            Electron.IpcMain.On("async-pagarOrden-pagarClienteOrdenes", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                int result = 1;

                try
                {

                    int idCliente = int.Parse(args.ToString());

                    result = pagarOrdenService.pagar(idCliente);

                    if (result == 1)
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Exito", "Cliente marcado como confirmado y sus ordenes pagadas")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };

                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 

                    }
                    else
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Error", "Algo esta pasando")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };
                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-pagarClienteOrdenes", result);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-pagarClienteOrdenes", ex.Message);
                }
            });


            //pagar personalizaso 
            Electron.IpcMain.On("async-pagarOrden-pagarClientePersonalizado", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                int result = -1;

                try
                {
                    Boleta boleta = new Boleta();

                   
                    List<Boleta> boletas = ((JArray)args).Select(x => new Boleta
                    {
                        IdBoleta = (int)x["id_cliente"] ,
                        MontoExtra = (int)x["valor_a_pagar"],
                        Operacion = (int)x["operacion"],
                        MotivoMontoExtra = (string)x["motivo"]
                    }).ToList();

                    

                    boleta = boletas[0];


                    result = pagarOrdenService.pagarPersonalizado(boleta);

                    if (result == 1)
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Exito", "Cliente marcado como confirmado y sus ordenes pagadas")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };

                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 

                    }
                    else
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Error", "Algo esta pasando")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };
                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-pagarClientePersonalizado", result);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-pagarClientePersonalizado", ex.Message);
                }
            });




            //CARGAR ordenes del cliente
            Electron.IpcMain.On("async-pagarOrden-ordenesClienteInbox", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {

                    //
                    //FALTAAAAAAAAAAAAAAAAA
                    //
                    //

                    int idCliente = int.Parse(args.ToString());

                    int total = pagarOrdenService.getClienteTotalApagarOrden(idCliente);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-ordenesClienteInbox", total);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pagarOrden-ordenesClienteInbox", ex.Message);
                }
            });


            //CARGAR LAS ORDENES DEL MAIN   async-Nombre  cliente 
            Electron.IpcMain.On("async-receta-pagarOrden-cliente", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CocinaService cocinaService = new CocinaService();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {
                    int idCliente = int.Parse(args.ToString());

                   
                    List<OrdenCocina> ordenesCocina = pagarOrdenService.getOrdenesByCliente(idCliente);

                  

                    cocinaService = null;

                    cocinaService = new CocinaService();


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-pagarOrden-cliente", cocinaService.completarOrden(ordenesCocina));
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-pagarOrden-cliente", ex.Message);
                }
            });


            //buscar los clientes 
            Electron.IpcMain.On("async-receta-pagarOrden-buscarCliente", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

               
                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {
                    string busqueda = args.ToString();

                    List<Cliente> resultados = pagarOrdenService.getClienteMesaBuscar(busqueda);

                    pagarOrdenService = null;

                    pagarOrdenService = new PagarOrdenService();
                    List<Cliente> all = pagarOrdenService.getClienteMesa();


                    List<Cliente> final = pagarOrdenService.completarClienteBusqueda(resultados, all, busqueda);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-pagarOrden-buscarCliente", final);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-pagarOrden-buscarCliente", ex.Message);
                }
            });



            //cargar el modal 
            Electron.IpcMain.On("modalReceta-pagarOrden-window", async (argument) =>
            {
                //carga el puerto disponible
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/PagarOrden/modalrecetapago?idReceta={argument}";

                var optionsWindows = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(optionsWindows, viewPath);
            });
            //cargar un modal 





            return View();
        }


        public IActionResult ModalRecetaPago(string idReceta)
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

    }
}