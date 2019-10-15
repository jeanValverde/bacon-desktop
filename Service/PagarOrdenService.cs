using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class PagarOrdenService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;

        public PagarOrdenService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }

        //para llamar a un procedure con cursor 
        public List<Cliente> getClienteMesa()
        {
            cmd.CommandText = "PACKAGE_CLIENTE.PR_LISTAR_CLIENTE_ORDEN";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_CLIENTES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Cliente> clientes = new List<Cliente>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {
                    Cliente cliente = new Cliente();

                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.Nombre = reader.GetString(1);

                    Mesa mesa = new Mesa();

                    mesa.NumeroMesa = reader.GetInt32(2);

                    cliente.Mesa = mesa;

                    clientes.Add(cliente);

                }

                con.Close();

                return clientes;

            }
            catch (Exception)
            {
                return clientes;
            }
        }

        public Cliente getClienteApagar(int idCliente)
        {
            cmd.CommandText = "PACKAGE_CLIENTE.PR_LISTAR_CLIENTE_DETALLE";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32).Value = idCliente;
            cmd.Parameters.Add("P_CLIENTES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            Cliente cliente = new Cliente();
            Mesa mesa = new Mesa();
            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {
                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.Nombre = reader.GetString(1);
                    cliente.FechaIngreso = reader.GetDateTime(2);

                    mesa.NumeroMesa = reader.GetInt32(3);
                    mesa.IdMesa = reader.GetInt32(4);
                    
                    break;

                }

                cliente.Mesa = mesa;

                con.Close();

                return cliente;


            }
            catch (Exception)
            {
                return cliente;
            }
        }

        public int getClienteApagarTotalOrden(int idCliente)
        {
            cmd.CommandText = "PACKAGE_CLIENTE.PR_TOTAL_ORDEN_CLIENTE";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32).Value = idCliente;

            cmd.Parameters.Add("V_TOTAL", OracleDbType.Int32).Direction = ParameterDirection.Output;


            int result = 0;

            try
            {

                cmd.ExecuteNonQuery();

                result = int.Parse(cmd.Parameters["V_TOTAL"].Value.ToString());

                con.Close();


                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }


        public int getClienteTotalApagarOrden(int idCliente)
        {
            cmd.CommandText = "PACKAGE_CLIENTE.PR_TOTAL_A_PAGAR_CLIENTE";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32).Value = idCliente;

            cmd.Parameters.Add("V_TOTAL", OracleDbType.Int32).Direction = ParameterDirection.Output;


            int result = 0;

            try
            {

                cmd.ExecuteNonQuery();

                result = int.Parse(cmd.Parameters["V_TOTAL"].Value.ToString());

                con.Close();


                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }



        public int pagar(int idCliente) 
        {
            cmd.CommandText = "PACKAGE_BOLETA.PR_INSERT_BOLETA_PAGAR_CLIENTE";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32).Value = idCliente;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;


            int result = 0;

            try
            {

                cmd.ExecuteNonQuery();

                result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();


                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }


        public int pagarPersonalizado(Boleta boleta)
        {
            cmd.CommandText = "PACKAGE_BOLETA.PR_INSERT_PAGAR_CLI_PERSO";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32).Value = boleta.IdBoleta;

            cmd.Parameters.Add("P_MONTO_EXTRA", OracleDbType.Int32).Value = boleta.MontoExtra;

            cmd.Parameters.Add("P_MOTIVO", OracleDbType.NVarchar2).Value = boleta.MotivoMontoExtra;

            cmd.Parameters.Add("P_OPERACION", OracleDbType.Int32).Value = boleta.Operacion;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;


            int result = 0;

            try
            {

                cmd.ExecuteNonQuery();

                result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();


                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }




    }
}
