using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bacon_desktop.Models;
using bacon_desktop.Service;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace bacon_desktop.Controllers
{
    public class TableroMesaController : Controller
    {
        public IActionResult Index()
        {
            //CARGAR LAS MESAS HABILITADAS DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-MesaHabilitada", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();


                Console.Write("hola");

                TableroMesaService tableroMesaService = new TableroMesaService();

                try
                {

                    List<Mesa> mesasHab = tableroMesaService.listarMesasHab();

                    tableroMesaService = null;


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-MesaHabilitada", mesasHab);




                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-MesaHabilitada", ex.Message);
                }
            });

            //CARGAR LAS MESAS DESHABILITADAS DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-MesasDeshabilitadass", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();


                Console.Write("hola");

                TableroMesaService tableroMesaService = new TableroMesaService();

                try
                {

                    List<Cliente> mesasHab = tableroMesaService.listarMesasDes();

                    tableroMesaService = null;


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-MesasDeshabilitadasss", mesasHab);




                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-MesasDeshabilitadasss", ex.Message);
                }
            });

            //CARGAR LAS MESAS EN ESPERA DEL MAIN   async-Nombre 
            Electron.IpcMain.On("async-MesaEspera", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();


                Console.Write("hola");

                TableroMesaService tableroMesaService = new TableroMesaService();

                try
                {

                    List<Mesa> mesasHab = tableroMesaService.listarMesasEspera();

                    tableroMesaService = null;


                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-MesaEspera", mesasHab);




                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-MesaEspera", ex.Message);
                }
            });

            Electron.IpcMain.On("async-ModificarMesa", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                TableroMesaService tableroMesaService = new TableroMesaService();

                try
                {
                    Mesa mesa = new Mesa();

                    List<Mesa> mesas = ((JArray)args).Select(x => new Mesa
                    {
                        IdMesa = (int)x["id_mesa"],
                        EstadoMesa = (int)x["estado_mesa"]
                    }).ToList();

                    mesa = mesas[0];

                    int result = tableroMesaService.cambiarEstadoMesa(mesa.IdMesa, mesa.EstadoMesa);

                    if (result == 1)
                    {

                        var options = new NotificationOptions("Exito", "Estado Cambiado")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("")
                        };

                        Electron.Notification.Show(options);

                    }
                    else
                    {
                        var options = new NotificationOptions("Error", "Estado No Cambiado")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("")
                        };

                        Electron.Notification.Show(options);
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ModificarMesa", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ModificarMesa", ex.Message);
                }
            });


            return View();
        }
    }
}