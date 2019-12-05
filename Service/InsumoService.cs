using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bacon_desktop.Service
{
    public class InsumoService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public InsumoService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }
       

        public List<Insumo> listarInsumosHaComprar()
        {
            List<Insumo> insumos = new List<Insumo>();

            try
            {

                cmd.CommandText = "PACKAGE_INSUMO.PR_LISTAR_INSUMOS";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("cursor_insumos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    Insumo insumo = new Insumo();

                    insumo.IdInsumo = reader.GetInt32(0);
                    insumo.NombreInusmo = reader.GetString(1);
                    insumo.DescripcionInusmo = reader.GetString(2);
                    insumo.StockInsumo = reader.GetInt32(3);
                    insumo.UnidadMedidaInsumo = reader.GetString(4);
                    insumo.MinStockInsumo = reader.GetInt32(5);
                    insumo.MaxStockInsumo = reader.GetInt32(6);
                    insumo.Foto = reader.GetString(7);

                   insumos.Add(insumo);

                }

                con.Close();

                return insumos;


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message.ToString());
                insumos = null;


                return insumos;
            }

        }
        public List<IngredienteInsumoReceta> listarInsumosCantidad()
        {
            List<IngredienteInsumoReceta> ingredientes = new List<IngredienteInsumoReceta>();

            try
            {

                cmd.CommandText = "PACKAGE_INSUMO.PR_INSUMOS_CANTIDAD";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_INSUMOS_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    IngredienteInsumoReceta ingrediente = new IngredienteInsumoReceta();
                    ingrediente.IdInsumo = reader.GetInt32(0);
                    ingrediente.Cantidad = reader.GetInt32(1);
                    ingrediente.Cantidad_diaria = reader.GetInt32(2);

                    ingredientes.Add(ingrediente);

                }

                con.Close();

                return ingredientes;


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message.ToString());
                ingredientes = null;


                return ingredientes;
            }

        }





    }
}
