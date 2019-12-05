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
using Oracle.ManagedDataAccess.Client;


namespace bacon_desktop.Controllers
{
    public class FinanzasController : Controller
    {
        
        public IActionResult IndexCierreCaja()
        {
            Electron.IpcMain.On("async-boletas-cierre-caja", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                
                
                try
                {


                    BoletaService boletaService = new BoletaService();
                    List<Boleta> boletasHoy = boletaService.listarBoletasDeHoy();
                    boletaService = null;
                    ControlCajaService controlCajaService = new ControlCajaService();
                    ControlCaja ultimoControlCaja = controlCajaService.retornarUltimoControlCaja();
                    controlCajaService = new ControlCajaService();
                    //DateTime fechaActual = new Date(day:)
                    // DateTime fechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    if (ultimoControlCaja != null)
                    {
                        if (ultimoControlCaja.FechaControlCaja.ToString("dd/MM/yy") == DateTime.Now.ToString("dd/MM/yy"))
                        {
                            //System.Console.WriteLine("fecha actual: " + DateTime.Now.ToString("dd/MM/yy"));
                            Electron.IpcMain.Send(mainWindow, "asynchronous-reply-boletas-cierre-caja", -1);
                        }
                        else
                        {

                            Electron.IpcMain.Send(mainWindow, "asynchronous-reply-boletas-cierre-caja", boletasHoy);

                        }
                    }
                    else
                    {
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-boletas-cierre-caja", boletasHoy);
                    }
                   // System.Console.WriteLine(ultimoControlCaja.FechaControlCaja);
                   


                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-boletas-cierre-caja", ex.Message);
                }
            });


            Electron.IpcMain.On("async-ultimo-cierre-caja", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                ControlCajaService controlCajaService = new ControlCajaService();
                try
                {
                    ControlCaja ultimoControlCaja = controlCajaService.retornarUltimoControlCaja();

                    controlCajaService = null;
                    if(ultimoControlCaja == null)
                    {
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ultimo-cierre-caja", -1);
                    }
                    else
                    {
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ultimo-cierre-caja", ultimoControlCaja);
                    }
                    
                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-ultimo-cierre-caja", ex.Message);
                }
            });

            Electron.IpcMain.On("modalBoleta-window-finanzas", async (argument) =>
            {
                //carga el puerto disponible
                string viewPath = $"http://localhost:{BridgeSettings.WebPort}/Finanzas/ModalBoletaFinanzas?idBoleta={argument}";
               // string viewPath = $"http://localhost:{BridgeSettings.WebPort}/Finanzas/ModalBoletaFinanzas";
                var optionsWindows = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(optionsWindows, viewPath);
            });
            Electron.IpcMain.On("async-cerrar-caja", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                var datos = args;
                List<ControlCaja> cj = ((JArray)args).Select(x => new ControlCaja
                {
                    MontoInicial = (int)x["montoInicial"],
                    TotalBoleta = (int)x["recaudacionHoy"],
                    MontoFinal = (int)x["montoFinal"]
                }).ToList();

                try
                {

                    ControlCajaService controlCajaService = new ControlCajaService();

                    // se debe cambiar la utilidad y el id del personal, ya que estan en duro
                     Boolean exito = controlCajaService.insertarControlCaja(cj[0].TotalBoleta, 1288, cj[0].MontoFinal, cj[0].MontoInicial, 195);
                    
                    if (exito)
                    {
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cerrar-caja", 1);
                    }
                    else
                    {
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cerrar-caja", -1);
                    }

                    
                    
                    

                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cerrar-caja", ex.Message);

                }
            });
            Electron.IpcMain.On("information-dialog-cierre-caja", async (args) =>
            {
                var options = new MessageBoxOptions("¿Seguro que desea cerrar la caja?")
                {
                    Type = MessageBoxType.info,
                    Title = "Informatión",
                    Buttons = new string[] { "Si", "No" }
                };

                //var p= Microsoft.VisualBasic.Interaction.InputBox("Question?", "Title", "Default Text");

                var result = await Electron.Dialog.ShowMessageBoxAsync(options);

                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                Electron.IpcMain.Send(mainWindow, "information-dialog-reply-cierre-caja", result.Response);
            });
            Electron.IpcMain.On("information-dialog-cambiarMontoFinal-cierre-caja", async (args) =>
            {
                var options = new MessageBoxOptions("¿Seguro que desea cambiar el valor del monto total?")
                {
                    Type = MessageBoxType.info,
                    Title = "Informatión",
                    Buttons = new string[] { "Si", "No" }
                };

               //var p= Microsoft.VisualBasic.Interaction.InputBox("Question?", "Title", "Default Text");
                
                var result = await Electron.Dialog.ShowMessageBoxAsync(options);

                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                Electron.IpcMain.Send(mainWindow, "information-dialog-reply-cambiarMontoFinal-cierre-caja", result.Response);
            });

            return View();
        }

        public IActionResult ModalBoletaFinanzas(int idBoleta)
        {
            BoletaService boletaService = new BoletaService();
            Boleta boleta = new Boleta();
            boleta = boletaService.retornarBoletaById(idBoleta);
            ViewData["Boleta"] = boleta;
            boletaService = null;
            boletaService = new BoletaService();
            List<RecetaOrdenada> ordenes = boletaService.listarOrdenesBoletaByIdCliente(boleta.Cliente.IdCliente);
            ViewData["Ordenes"] = ordenes;

            




            return View();
        }

    }
}