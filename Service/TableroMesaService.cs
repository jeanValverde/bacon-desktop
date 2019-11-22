using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class TableroMesaService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;

        public TableroMesaService()
        {
            connectionBacon = new ConnectionBacon();

            con = connectionBacon.Connection();

            cmd = con.CreateCommand();
        }

        public List<Mesa> listarMesasHab()
        {
            List<Mesa> mesasHab = new List<Mesa>();

            try
            {
                cmd.CommandText = "PACKAGE_MESA.PR_LISTAR_MESAS_HABILITADA";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("cursor_mesas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {

                    Mesa mesaHab = new Mesa();
                    
                    mesaHab.IdMesa = reader.GetInt32(0);
                    mesaHab.NumeroMesa = reader.GetInt32(1);
                    mesaHab.CantidadAsientosMesa = reader.GetInt32(2);
                    mesaHab.EstadoMesa = reader.GetInt32(3);
                    
                    mesasHab.Add(mesaHab);
                                       
                }
                con.Close();

                return mesasHab;
            }
            catch (Exception)
            {
                return mesasHab;
            }
        }

        public List<Cliente> listarMesasDes()
        {
            List<Cliente> mesasHab = new List<Cliente>();

            try
            {
                cmd.CommandText = "PACKAGE_MESA.PR_LISTAR_MESAS_DESHABILITADA";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("cursor_mesas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {

                    Cliente cliente = new Cliente();

                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.Nombre = reader.GetString(1);
                    cliente.FechaIngreso = reader.GetDateTime(2);

                    Mesa mesaHab = new Mesa();

                    mesaHab.NumeroMesa = reader.GetInt32(3);
                    mesaHab.CantidadAsientosMesa = reader.GetInt32(4);
                    mesaHab.EstadoMesa = reader.GetInt32(5);

                    cliente.Mesa = mesaHab;

                    mesasHab.Add(cliente);

                }
                con.Close();

                return mesasHab;
            }
            catch (Exception)
            {
                return mesasHab;
            }
        }

        public List<Mesa> listarMesasEspera()
        {
            List<Mesa> mesasHab = new List<Mesa>();

            try
            {
                cmd.CommandText = "PACKAGE_MESA.PR_LISTAR_MESAS_ESPERA";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("cursor_mesas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {

                    Mesa mesaHab = new Mesa();

                    mesaHab.IdMesa = reader.GetInt32(0);
                    mesaHab.NumeroMesa = reader.GetInt32(1);
                    mesaHab.CantidadAsientosMesa = reader.GetInt32(2);
                    mesaHab.EstadoMesa = reader.GetInt32(3);

                    mesasHab.Add(mesaHab);

                }
                con.Close();

                return mesasHab;
            }
            catch (Exception)
            {
                return mesasHab;
            }
        }

        public int cambiarEstadoMesa(int idMesa, int estado_mesa)
        {
            cmd.CommandText = "PACKAGE_MESA.PR_MODIFICAR_MESA_ESTADO";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_MESA", OracleDbType.Int32).Value = idMesa;

            cmd.Parameters.Add("P_ESTADO_MESA", OracleDbType.Int32).Value = estado_mesa;

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
