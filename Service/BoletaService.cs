using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bacon_desktop.Service
{
    public class BoletaService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public BoletaService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }
        public Boleta retornarBoletaById(int idBoleta)
        {
            
            Boleta boleta = new Boleta();
            try
            {

                cmd.CommandText = "PACKAGE_BOLETA.PR_BOLETA";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_ID_BOLETA", OracleDbType.Int32).Value = idBoleta;
                cmd.Parameters.Add("CURSOR_BOLETA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {


                    boleta.IdBoleta = reader.GetInt32(0);
                    System.Console.WriteLine(reader.GetInt32(0));
                    boleta.TotalMesa = reader.GetInt32(1);
                    boleta.Vuelto = reader.GetInt32(2);
                    boleta.MontoPagado = reader.GetInt32(3);
                    if (reader.IsDBNull(4))
                    {
                        boleta.Fecha = new DateTime();
                    }
                    else
                    {
                        boleta.Fecha = reader.GetDateTime(4);
                    }

                    if (reader.IsDBNull(5))
                    {
                        boleta.MontoExtra = -1;
                    }
                    else
                    {
                        boleta.MontoExtra = reader.GetInt32(5);
                    }

                    if (reader.IsDBNull(6))
                    {
                        boleta.MotivoMontoExtra = "";
                    }
                    else
                    {
                        boleta.MotivoMontoExtra = reader.GetString(6);
                    }

                    if (reader.IsDBNull(7))
                    {
                        boleta.Operacion = -1;
                    }
                    else
                    {
                        boleta.Operacion = reader.GetInt32(7);
                    }

                    Cliente cliente = new Cliente();
                    cliente.IdCliente = reader.GetInt32(8);
                    boleta.Cliente = cliente;
                    MedioPago medioPago = new MedioPago();
                    medioPago.IdMedioPago = reader.GetInt32(9);
                    boleta.MedioPago = medioPago;

                }

                con.Close();

                return boleta;


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message.ToString());
                boleta = null;

                return boleta;
            }

        }

        public List<Boleta> listarBoletasDeHoy()
        {
            List<Boleta> boletasHoy = new List<Boleta>();

            try
            {

                cmd.CommandText = "PACKAGE_BOLETA.PR_LISTAR_BOLETAS_HOY";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_BOLETAS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {

                    Boleta boleta = new Boleta();

                    boleta.IdBoleta = reader.GetInt32(0);
                    boleta.TotalMesa = reader.GetInt32(1);
                    if (reader.IsDBNull(2))
                    {
                        boleta.Fecha = new DateTime();
                    }
                    else
                    {
                        boleta.Fecha = reader.GetDateTime(2);
                    }

                    if (reader.IsDBNull(3))
                    {
                        boleta.MontoExtra = -1;
                    }
                    else
                    {
                        boleta.MontoExtra = reader.GetInt32(3);
                    }
                        
                    if (reader.IsDBNull(4))
                    {
                        boleta.MotivoMontoExtra = "";
                    }
                    else
                    {
                        boleta.MotivoMontoExtra = reader.GetString(4);
                    }

                    if (reader.IsDBNull(5))
                    {
                        boleta.Operacion = -1;
                    }
                    else
                    {
                        boleta.Operacion = reader.GetInt32(5);
                    }
                    


                    Cliente cliente = new Cliente();
                    cliente.IdCliente = reader.GetInt32(6);
                    boleta.Cliente = cliente;
                    MedioPago medioPago = new MedioPago();
                    medioPago.IdMedioPago = reader.GetInt32(7);
                    boleta.MedioPago = medioPago;

                   boletasHoy.Add(boleta);

                }

                con.Close();

                return boletasHoy;


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message.ToString());
                boletasHoy = null;


                return boletasHoy;
            }

        }

        public List<RecetaOrdenada> listarOrdenesBoletaByIdCliente(int idCliente)
        {
            List<RecetaOrdenada> ordenes = new List<RecetaOrdenada>();
            


            try
            {

                cmd.CommandText = "PACKAGE_CONTROL_CAJA.PR_ORDENES_BOLETA";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID_CLIENTE", OracleDbType.Int32).Value = idCliente;
                cmd.Parameters.Add("CURSOR_ORDENES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    RecetaOrdenada recetaOrdenada = new RecetaOrdenada();
                    Receta receta = new Receta();

                    receta.NombreReceta = reader.GetString(0);
                    receta.PrecioReceta = reader.GetInt32(1);
                    recetaOrdenada.Receta = receta;
                    recetaOrdenada.Cantidad = reader.GetInt32(2);
                    recetaOrdenada.Valor = reader.GetInt32(3);

                    ordenes.Add(recetaOrdenada);

                }

                con.Close();

                return ordenes;


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message.ToString());
                ordenes = null;

                return ordenes;
            }

        }



    }
}
