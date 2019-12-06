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
using Newtonsoft.Json.Linq;

namespace bacon_desktop.Controllers
{
    public class CalcularPedidosManualesController : Controller
    {
        public IActionResult IndexCalcularPedidosManuales()
        {
            //Cargar las vistas de calcular Pedidos manuales 
            Electron.IpcMain.On("async-cargarVistasCalcularPedidos", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CalcularPedidosManualesService calcularPedidos = new CalcularPedidosManualesService();
                try
                {
                    List<Insumo> insumo = calcularPedidos.listarInsumos();

                    calcularPedidos = null;

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasCalcularPedidos", insumo);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasCalcularPedidos", ex.Message);
                }
            });

            //Cargar las vistas de calcular Pedidos manuales 
            Electron.IpcMain.On("async-cargarVistasInsumosPedidos", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CalcularPedidosManualesService calcularPedidos = new CalcularPedidosManualesService();
                try
                {
                    List<InsumoPedido> insumos = calcularPedidos.listarInsumosPedidos();

                    calcularPedidos = null;

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasInsumosPedidos", insumos);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasInsumosPedidos", ex.Message);
                }
            });

            Electron.IpcMain.On("async-cargarVistasInsumosPedidos2", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CalcularPedidosManualesService calcularPedidos = new CalcularPedidosManualesService();
                try
                {
                    List<InsumoPedido> insumos = calcularPedidos.listarInsumosPedidos();

                    calcularPedidos = null;

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasInsumosPedidos", insumos);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasInsumosPedidos", ex.Message);
                }
            });


            Electron.IpcMain.On("async-cargarVistasInsumosId", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                CalcularPedidosManualesService calcularPedidos = new CalcularPedidosManualesService();
                try
                {
                    int idInsumo = int.Parse(args.ToString());
                    Insumo insumos = calcularPedidos.listarInsumoById(idInsumo);
                   
                    calcularPedidos = null;
                    
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasInsumosId", insumos);
                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-cargarVistasInsumosId", ex.Message);
                }
            });

            

            //Cargar las vistas de calcular Pedidos manuales 
            Electron.IpcMain.On("async-agregarInsumoPedido", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                var datos = args;
                List<InsumoPedido> insumoPedido = ((JArray)args).Select(x => new InsumoPedido
                {
                    EstadoInsumoPedido = (int)x["idInsumo"],
                    CantidadInsumo = (int)x["cantidad"]
                    
                }).ToList();

                CalcularPedidosManualesService calcularPedidos = new CalcularPedidosManualesService();
                try
                {

                    //if (calcularPedidos.insertarCantidadInsumo(insumoPedido[0].CantidadInsumo,insumoPedido[0].EstadoInsumoPedido)==1)
                    //{
                    //    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-agregarInsumoPedido", 1);
                    //}
                    //else
                    //{
                    //    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-agregarInsumoPedido", -1);
                    //}

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-agregarInsumoPedido", 1);


                }
                catch (Exception ex)
                {

                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-agregarInsumoPedido", ex.Message);
                }
            });


            return View();
        }


    }
}