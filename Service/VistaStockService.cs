using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class VistaStockService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public VistaStockService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }

        public List<IngresoStock> listarVistasStock()
        {
            List<IngresoStock> ingresos = new List<IngresoStock>();

            try
            {
                cmd.CommandText = "PACKAGE_STOCK.PR_LISTAR_VISTAS_STOCK";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_STOCK", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();
                foreach (var item in reader)
                {
                    IngresoStock ingreso = new IngresoStock();


                    ingreso.IdIngresoStock = reader.GetInt32(0);
                    Insumo insumo = new Insumo();
                    insumo.IdInsumo = reader.GetInt32(1);
                    insumo.NombreInusmo = reader.GetString(2);
                    insumo.UnidadMedidaInsumo = reader.GetString(3);
                    insumo.Foto = reader.GetString(4);
                    ingreso.Insumo = insumo;
                    ingreso.FechaIngreso = reader.GetDateTime(5);
                    ingreso.FechaCaducidad = reader.GetDateTime(6);
                    ingreso.Cantidad = reader.GetInt32(7);
                    ingreso.Estado = reader.GetInt32(8);

                    

                    ingresos.Add(ingreso);
                  
                }
                con.Close();

                return ingresos;
                
            }
            catch (Exception)
            {
                return ingresos;
            }
        }

        public List<IngresoStock> listarVistasStockHistorico()
        {
            List<IngresoStock> ingresos = new List<IngresoStock>();

            try
            {
                cmd.CommandText = "PACKAGE_STOCK.PR_LISTAR_VISTAS_HISTORICO";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_STOCK_HISTORICO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();
                foreach (var item in reader)
                {
                    IngresoStock ingreso = new IngresoStock();


                    ingreso.IdIngresoStock = reader.GetInt32(0);
                    Insumo insumo = new Insumo();
                    insumo.IdInsumo = reader.GetInt32(1);
                    insumo.NombreInusmo = reader.GetString(2);
                    insumo.UnidadMedidaInsumo = reader.GetString(3);
                    insumo.Foto = reader.GetString(4);
                    ingreso.Insumo = insumo;
                    ingreso.FechaIngreso = reader.GetDateTime(5);
                    ingreso.FechaCaducidad = reader.GetDateTime(6);
                    ingreso.Cantidad = reader.GetInt32(7);
                    ingreso.Estado = reader.GetInt32(8);

                    

                    ingresos.Add(ingreso);

                }
                con.Close();

                return ingresos;

            }
            catch (Exception)
            {
                return ingresos;
            }
        }

        //UPDATE NOTIFICACION VISTAS STOCK
        public int cambiarEstadoNotificacionVistaStock(int idIngresoStock)
        {
            cmd.CommandText = "PACKAGE_STOCK.PR_SET_ESTADO_NOTIFY_STOCK";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACION_STOCK", OracleDbType.Int32).Value = idIngresoStock;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;

            try
            {

                cmd.ExecuteNonQuery();

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
