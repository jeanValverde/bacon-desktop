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
    public class InsumosNecesariosController : Controller
    {
        
        public IActionResult IndexInsumosNecesarios()
        {
            Electron.IpcMain.On("async-insumos-comprar", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();

                try
                {
                    InsumoService insumoService = new InsumoService();
                    List<Insumo> insumos = insumoService.listarInsumosHaComprar();
                    insumoService = new InsumoService();
                    List<InsumoCantidad> insumosCantidad = new List<InsumoCantidad>();


                    insumoService = new InsumoService();
                    if (insumos != null)
                    {

                        List<IngredienteInsumoReceta> insumosConCantidad = new List<IngredienteInsumoReceta>();
                        insumosConCantidad = insumoService.listarInsumosCantidad();
                        insumoService = new InsumoService();
                        for (int i = 0; i < insumos.Count; i++)
                        {
                            InsumoCantidad insumoCantidad = new InsumoCantidad();
                            Insumo insumo = new Insumo();
                            insumo.IdInsumo = insumos[i].IdInsumo;
                            insumo.NombreInusmo = insumos[i].NombreInusmo;
                            insumo.DescripcionInusmo = insumos[i].DescripcionInusmo;
                            insumo.StockInsumo = insumos[i].StockInsumo;
                            insumo.UnidadMedidaInsumo = insumos[i].UnidadMedidaInsumo;
                            insumo.MinStockInsumo = insumos[i].MinStockInsumo;
                            insumo.MaxStockInsumo = insumos[i].MaxStockInsumo;
                            insumo.Foto = insumos[i].Foto;
                            insumoCantidad.Insumo = insumo;
                            double cantidad = 0;
                            System.Console.WriteLine("iNSUMO: "+insumos[i].IdInsumo);
                            for (int y = 0; y < insumosConCantidad.Count; y++)
                            {

                                if (insumosConCantidad[y].IdInsumo == insumos[i].IdInsumo)
                                {
                                    
                                    cantidad = cantidad + (((double)insumosConCantidad[y].Cantidad / 1000) * (double)insumosConCantidad[y].Cantidad_diaria);
                                    
                                }
                            }
                            //System.Console.WriteLine(cantidad);
                            insumoCantidad.Cantidad = Math.Round(cantidad,2);
                            if (insumoCantidad.Cantidad>insumo.StockInsumo)
                            {
                                insumoCantidad.CantidadHaComprar = Math.Round((insumoCantidad.Cantidad - insumo.StockInsumo),2);
                            }
                            else
                            {
                                insumoCantidad.CantidadHaComprar = 0.0;
                            }



                            insumosCantidad.Add(insumoCantidad);
                        }
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-insumos-comprar", insumosCantidad);
                        

                    }
                    else
                    {
                        
                        Electron.IpcMain.Send(mainWindow, "asynchronous-reply-insumos-comprar", -1);
                    }
                    // System.Console.WriteLine(ultimoControlCaja.FechaControlCaja);



                }
                catch (Exception ex)
                {
                    Electron.IpcMain.Send(mainWindow, "asynchronous-reply-boletas-cierre-caja", ex.Message);
                }
            });

            return View();
        }

       

    }
}