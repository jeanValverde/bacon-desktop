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
    public class PedirOrdenGarzonController : Controller
    {
        public IActionResult Index()
        {

            //CARGAR  los clientes 
            Electron.IpcMain.On("async-pedirOrdenGarzon-clientes", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {
                    List<Cliente> clientes = pagarOrdenService.getClienteMesa();

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrdenGarzon-clientes", clientes);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrdenGarzon-clientes", ex.Message);
                }
            });

            //CARGAR cliente 
            Electron.IpcMain.On("async-pedirOrdenGarzon-clienteDetalle", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {

                    int idCliente = int.Parse(args.ToString());

                    Cliente cliente = pagarOrdenService.getClienteApagar(idCliente);

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrdenGarzon-clienteDetalle", cliente);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrdenGarzon-clienteDetalle", ex.Message);
                }
            });

            //CARGAR LAS ORDENES DEl cliente 
            Electron.IpcMain.On("async-pedirOrdenGarzon-ordenes-cargar", (args) =>
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


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrdenGarzon-ordenes-cargar", cocinaService.completarOrden(ordenesCocina));
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrdenGarzon-ordenes-cargar", ex.Message);
                }
            });

            //buscar los clientes 
            Electron.IpcMain.On("async-receta-pedirOrdenGarzon-buscarCliente", (args) =>
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

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-pedirOrdenGarzon-buscarCliente", final);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-receta-pedirOrdenGarzon-buscarCliente", ex.Message);
                }
            });


            //CARGAR 
            Electron.IpcMain.On("async-pedirOrden-eliminarCliente", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                PagarOrdenService pagarOrdenService = new PagarOrdenService();

                try
                {

                    int idCliente = int.Parse(args.ToString());

                    Cliente cliente = new Cliente();

                    cliente.IdCliente = idCliente;

                    int exito = pagarOrdenService.eliminarClienteById(cliente);


                    if (exito == 1)
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Exito", "Cliente número " + idCliente + " fue eliminado")
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
                        var options = new NotificationOptions("Error", "Algo mal paso")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };
                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 
                    }


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrden-eliminarCliente", cliente);
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-pedirOrden-eliminarCliente", ex.Message);
                }
            });


            return View();
        }
    }
}