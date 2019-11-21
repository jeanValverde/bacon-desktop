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
    public class VistaStockController : Controller
    {
        public IActionResult VistasStock()
        {
            //Cargar las vistas de ingreso Stock
            Electron.IpcMain.On("async-cargarVistasStock", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                VistaStockService vistaStock = new VistaStockService();
                try
                {
                    List<IngresoStock> ingreso = vistaStock.listarVistasStock();

                    vistaStock = null;

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistaStock", ingreso);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistaStock", ex.Message);
                }
            });

            Electron.IpcMain.On("async-cargarVistasStockHistorico", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                VistaStockService vistaStock = new VistaStockService();
                try
                {
                    List<IngresoStock> ingreso = vistaStock.listarVistasStockHistorico();

                    vistaStock = null;

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistaStockHistorico", ingreso);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistaStockHistorico", ex.Message);
                }
            });


            Electron.IpcMain.On("async-vistasStock-notify-leido", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                VistaStockService vistasStock = new VistaStockService();

                try
                {
                    int idIngresoStock = int.Parse(args.ToString());

                    int result = vistasStock.cambiarEstadoNotificacionVistaStock(idIngresoStock);
                    
                    if (result == 1)
                    {
                        //carga una notificacion 
                        var options = new NotificationOptions("Exito", "Insumo marcado como utilizado")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };

                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 
                    }
                    else
                    {
                        var options = new NotificationOptions("Error", "Insumo no fue marcado como utilizado")
                        {
                            OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync(""),
                            Icon = "/images/cerdito.png"
                        };

                        Electron.Notification.Show(options);
                        //termina de cargar una notificacion 
                    }

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-vistasStock-notify-leido", result);

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-vistasStock-notify-leido", ex.Message);
                }
            });

            return View();
        }
    }
}