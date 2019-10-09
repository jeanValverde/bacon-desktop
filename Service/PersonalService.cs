using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class PersonalService
    {
        //siempre crear atributos de acceso a datos 
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;

        
        //siempre instacion los accesos a datos 
        public PersonalService()
        {
             //instacia la conexion a la base de datos  
             connectionBacon = new ConnectionBacon();

             // obtenemos a conexion 
             con = connectionBacon.Connection();

             //para crear hacer sentencias o llamarlas    
             cmd = con.CreateCommand();
        }

        public Personal getPersonalByRut(string rut)
        {
            cmd.CommandText = "PACKAGE_PERSONAL.PR_FIND_PERSONAL_BY_RUT";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_RUT_PERSONAL", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("CURSOR_PERSONAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            Personal personal = new Personal();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                Rol rol = new Rol();
                foreach (var item in reader)
                {

                    personal.Rut_personal = reader.GetString(0);
                    personal.Nombres_personal = reader.GetString(1);
                    personal.Ape_paterno_personal = reader.GetString(2);
                    personal.Contrasena_personal = reader.GetString(3);
                    rol.Descripcion_rol = reader.GetString(4);
                    personal.Rol = rol;

                    break;

                }

                con.Close();

                return personal;


            }
            catch (Exception )
            { 
                return personal;
            }
        }
        

        //NO USAR (hacer sentencias SQL)
        public List<Personal> getPersonal()
        {
            List<Personal> personas = new List<Personal>();


            try
            {
                
                cmd.CommandText = " select nombres_personal from personal ";

              

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    Personal personal = new Personal();

                    personal.Nombres_personal = reader.GetString(0);

                    personas.Add(personal);

                }

                //reader.Dispose();

            }
            catch (Exception )
            {

            }

            return personas;
        }


        //para llamar a un procedure con cursor 
        public List<Personal> getP()
        {
            cmd.CommandText = "PACKAGE_PERSONAL.PR_LISTAR_PERSONAL";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("CURSOR_PERSONAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Personal> personas = new List<Personal>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();
                

                foreach (var item in reader)
                {
                    Personal personal = new Personal();

                    personal.Nombres_personal = reader.GetString(0);

                    personas.Add(personal);

                }

                con.Close();

                return personas;


            }
            catch (Exception ex)
            {
                Personal p = new Personal();
                p.Nombres_personal = "error: " + ex.Message;
                personas.Add(p);
                return personas;
            }
        }


        //procedure para llamar cursor con parametros
        public List<Personal> getPbyID(int id) 
        {
            cmd.CommandText = "PACKAGE_PERSONAL.PR_LISTAR_PERSONAL_BY_ID";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_ORDEN", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("CURSOR_PERSONAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


            List<Personal> personas = new List<Personal>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {
                    Personal personal = new Personal();

                    personal.Nombres_personal = reader.GetString(0);

                    personas.Add(personal);

                }

                con.Close();

                return personas;


            }
            catch (Exception ex)
            {
                Personal p = new Personal();
                p.Nombres_personal = "error: " + ex.Message;
                personas.Add(p);
                return personas;
            }
        }

        //insert procedure con confirmacion y exepciones 
        public List<Personal> insertPersonal(int numMesa, int estado, int cantidad)
        {
            cmd.CommandText = "PR_INSERT_MESA_RETURN";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NUMERO_MESA", OracleDbType.Int32).Value = numMesa;
            cmd.Parameters.Add("P_CANTIDAD_ASIENTOS_MESA", OracleDbType.Int32).Value = cantidad;
            cmd.Parameters.Add("P_ESTADO_MESA", OracleDbType.Int32).Value = estado;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;

            
            List<Personal> personas = new List<Personal>();

            try
            {

                cmd.ExecuteNonQuery();

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();

                Personal p = new Personal();
                p.Nombres_personal = "mg: " + result ;
                personas.Add(p);

                return personas;
         
            }
            catch (Exception ex)
            {
                Personal p = new Personal();
                p.Nombres_personal = "error: " + ex.Message;
                personas.Add(p);
                return personas;
            }
        }


        //eliminar con confirmacion 
        public List<Personal> eliminar(int id) 
        {
            cmd.CommandText = "PR_ELIMINAR_MESA";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_MESA", OracleDbType.Int32).Value = id;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;


            List<Personal> personas = new List<Personal>();

            try
            {

                cmd.ExecuteNonQuery();

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();

                Personal p = new Personal();
                p.Nombres_personal = "mg: " + result;
                personas.Add(p);

                return personas;

            }
            catch (Exception ex)
            {
                Personal p = new Personal();
                p.Nombres_personal = "error: " + ex.Message;
                personas.Add(p);
                return personas;
            }
        }



        //update procedure con confirmacion y exepciones 
        public List<Personal> update(int id , int numMesa, int estado, int cantidad)
        {
            cmd.CommandText = "PR_MODIFICAR_MESA_return";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_MESA", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("P_NUMERO_MESA", OracleDbType.Int32).Value = numMesa;
            cmd.Parameters.Add("P_CANTIDAD_ASIENTOS_MESA", OracleDbType.Int32).Value = cantidad;
            cmd.Parameters.Add("P_ESTADO_MESA", OracleDbType.Int32).Value = estado;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;


            List<Personal> personas = new List<Personal>();

            try
            {

                cmd.ExecuteNonQuery();

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();

                Personal p = new Personal();
                p.Nombres_personal = "mg: " + result;
                personas.Add(p);

                return personas;

            }
            catch (Exception ex)
            {
                Personal p = new Personal();
                p.Nombres_personal = "error: " + ex.Message;
                personas.Add(p);
                return personas;
            }
        }










    }
}
