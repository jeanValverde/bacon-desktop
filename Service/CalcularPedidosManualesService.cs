using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class CalcularPedidosManualesService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public CalcularPedidosManualesService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }


        public int insertarCantidadInsumo( int cantInsumo, int idInsumo)
        {
            cmd.CommandText = "PACKAGE_BODEGA.PR_INSERT_INSUMO_PEDIDO";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_CANTIDAD_INSUMO", OracleDbType.Int32).Value = cantInsumo;

            cmd.Parameters.Add("P_ID_INSUMO", OracleDbType.Int32).Value = idInsumo;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;

            List<InsumoPedido> insumoPedido = new List<InsumoPedido>();

            try
            {
                cmd.ExecuteNonQuery();

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());


                InsumoPedido insumoP = new InsumoPedido();
                insumoP.CantidadInsumo = cantInsumo;
               
                con.Close();

                return result;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        public List<Insumo> listarInsumos()
        {
            List<Insumo> insumos = new List<Insumo>();

            try
            {
                cmd.CommandText = "PACKAGE_BODEGA.PR_LISTAR_INSUMO";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_INSUMOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    Insumo insumo = new Insumo();
                    insumo.IdInsumo = reader.GetInt32(0);
                    insumo.Foto = reader.GetString(1);
                    insumo.NombreInusmo = reader.GetString(2);
                    insumo.StockInsumo = reader.GetInt32(3);
                    insumo.UnidadMedidaInsumo = reader.GetString(4);
                    insumo.MaxStockInsumo = reader.GetInt32(5);
                    insumo.MinStockInsumo = reader.GetInt32(6);
                    InsumoPedido insumoPe = new InsumoPedido();
                    insumoPe.IdInsumoPedido = reader.GetInt32(7);
                    insumoPe.CantidadInsumo = reader.GetInt32(8);
                    insumoPe.EstadoInsumoPedido = reader.GetInt32(9);

                    insumos.Add(insumo);

                    
                }
                con.Close();
                return insumos;
            }
            catch (Exception)
            {

                return insumos;
            }
        }

        public List<InsumoPedido> listarInsumosPedidos()
        {
            List<InsumoPedido> insumosPedidos = new List<InsumoPedido>();

            try
            {
                cmd.CommandText = "PACKAGE_BODEGA.PR_LISTAR_INSUMO_PEDIDO";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_INSUMO_PEDIDO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    InsumoPedido insumoPedido = new InsumoPedido();
                    insumoPedido.IdInsumoPedido = reader.GetInt32(0);
                    insumoPedido.CantidadInsumo = reader.GetInt32(1);
                    insumoPedido.EstadoInsumoPedido = reader.GetInt32(2);  
                    Insumo insumo = new Insumo();
                    insumoPedido.Insumo = insumo;
                    insumo.IdInsumo = reader.GetInt32(3);
                    insumo.Foto = reader.GetString(4);
                    insumo.NombreInusmo = reader.GetString(5);
                    insumo.StockInsumo = reader.GetInt32(6);
                    insumo.MinStockInsumo = reader.GetInt32(7);
                    insumo.MaxStockInsumo = reader.GetInt32(8);
                    insumo.UnidadMedidaInsumo = reader.GetString(9);

                    insumosPedidos.Add(insumoPedido);


                }
                con.Close();
                return insumosPedidos;
            }
            catch (Exception)
            {

                return insumosPedidos;
            }
        }

        public Insumo listarInsumoById(int idInsumo)
        {
            
            Insumo insumo = new Insumo();
            try
            {
                cmd.CommandText = "PACKAGE_BODEGA.PR_LISTAR_INSUMO_ID";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_INSUMOS_ID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("P_ID_INSUMO", OracleDbType.Int32).Value = idInsumo;

                OracleDataReader reader = cmd.ExecuteReader();
                
                foreach (var item in reader)
                {



                    
                    insumo.IdInsumo = reader.GetInt32(0);
                    insumo.Foto = reader.GetString(1);
                    insumo.NombreInusmo = reader.GetString(2);
                    insumo.DescripcionInusmo = reader.GetString(3);
                    insumo.MaxStockInsumo = reader.GetInt32(4);
                    insumo.MinStockInsumo = reader.GetInt32(5);
                    insumo.StockInsumo = reader.GetInt32(6);
                    insumo.UnidadMedidaInsumo = reader.GetString(7);
                    break;
                    
                }
                con.Close();
                return insumo;

            }
            
            catch (Exception)
            {

                return insumo;
            }
        } 

        
    }
}
