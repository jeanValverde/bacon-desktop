using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bacon_desktop.Service
{
    public class ControlCajaService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public ControlCajaService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }

        public ControlCaja retornarUltimoControlCaja()
        {
            ControlCaja controlCaja = new ControlCaja();

            try
            {

                cmd.CommandText = "PACKAGE_CONTROL_CAJA.PR_ULTIMO_CONTROL_CAJA";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_CONTROL_CAJA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                OracleDataReader reader = cmd.ExecuteReader();
               
                
                
                foreach (var item in reader)
                {

                    controlCaja.IdControlCaja = reader.GetInt32(0);
                    controlCaja.FechaControlCaja = reader.GetDateTime(1);
                    controlCaja.TotalBoleta = reader.GetInt32(2);
                    controlCaja.UtilidadBruta = reader.GetInt32(3);
                    controlCaja.MontoFinal = reader.GetInt32(4);
                    System.Console.WriteLine("monto final" + reader.GetValue(4));
                    controlCaja.MontoInicial = reader.GetInt32(5);
                    Personal personal = new Personal();
                    personal.IdPersonal = reader.GetInt32(6);
                    controlCaja.Personal = personal;
                   
                    

                }
                if (!reader.HasRows)
                {
                    controlCaja = null;
                    
                }


                con.Close();

                return controlCaja;


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message.ToString());
                controlCaja = null;


                return controlCaja;
            }

        }
        public Boolean insertarControlCaja(int totalBoleta,int utilidadBruta,int montoFinal,int montoInicial,int idPersonal)
        {
            
            cmd.CommandText = "PACKAGE_CONTROL_CAJA.PR_INSERT_CONTROL_CAJA";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_CONTROL_CAJA", OracleDbType.Int32).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("P_TOTAL_BOLETAS", OracleDbType.Int32).Value = totalBoleta;
            cmd.Parameters.Add("P_UTILIDAD_BRUTA", OracleDbType.Int32).Value = utilidadBruta;
            cmd.Parameters.Add("P_MONTO_FINAL", OracleDbType.Int32).Value = montoFinal;
            cmd.Parameters.Add("P_MONTO_INICIAL", OracleDbType.Int32).Value = montoInicial;
            cmd.Parameters.Add("P_ID_PERSONAL", OracleDbType.Int32).Value = idPersonal;
            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;
            
            try
            {
                cmd.ExecuteNonQuery();
                

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());
                con.Close();
                if (result == 1)
                {
                    return true;
                }
                else 
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }



        }
}
