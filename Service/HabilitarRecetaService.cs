using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class HabilitarRecetaService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;

        public HabilitarRecetaService()
        {
            connectionBacon = new ConnectionBacon();

            con = connectionBacon.Connection();

            cmd = con.CreateCommand();
        }

        public List<Receta> listarRecetasHab()
        {
            List<Receta> recetasHab = new List<Receta>();

            try
            {
                cmd.CommandText = "PACKAGE_RECETA.PR_LISTAR_RECETAS_DISP_HAB";


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_RECETAS_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    Receta recetaHab = new Receta();


                    recetaHab.IdReceta = reader.GetInt32(0);
                    recetaHab.NombreReceta = reader.GetString(1);
                    recetaHab.DescripcionReceta = reader.GetString(2);
                    recetaHab.DuracionPreparacion = reader.GetInt32(3);
                    recetaHab.DisponibilidadReceta = reader.GetInt32(4);
                    recetaHab.PrecioReceta = reader.GetInt32(5);
                    recetaHab.CantidadPrepacionDiaria = reader.GetInt32(6);
                    recetaHab.Foto = reader.GetString(7);
                    recetaHab.TipoReceta = int.Parse(reader.GetString(8));

                    CategoriaReceta categoriaReceta = new CategoriaReceta();

                    categoriaReceta.IdCategoriaReceta = reader.GetInt32(9);

                    recetaHab.CategoriaReceta = categoriaReceta;

                    recetasHab.Add(recetaHab);



                }
                con.Close();

                return recetasHab;
            }
            catch (Exception)
            {
                return recetasHab;
            }
        }

        public int habilitarDisponibilidad(int idReceta)
        {
            cmd.CommandText = "PACKAGE_RECETA.PR_MODIFICAR_RECETA";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_RECETA", OracleDbType.Int32).Value = idReceta;

            cmd.Parameters.Add("P_DISPONIBILIDAD_RECETA", OracleDbType.Int32).Value = 1;

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
