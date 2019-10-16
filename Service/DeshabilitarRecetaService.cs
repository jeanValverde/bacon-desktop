using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class DeshabilitarRecetaService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;

        public DeshabilitarRecetaService()
        {
            connectionBacon = new ConnectionBacon();

            con = connectionBacon.Connection();

            cmd = con.CreateCommand();
        }

        public List<Receta> listarRecetas()
        {
            List<Receta> recetas = new List<Receta>();

            try
            {
                cmd.CommandText = "PACKAGE_RECETA.PR_LISTAR_RECETAS";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_RECETAS_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {
                    Receta receta = new Receta();

                    receta.IdReceta = reader.GetInt32(0);
                    receta.NombreReceta = reader.GetString(1);
                    receta.DescripcionReceta = reader.GetString(2);
                    receta.DuracionPreparacion = reader.GetInt32(3);
                    receta.DisponibilidadReceta = reader.GetInt32(4);
                    receta.PrecioReceta = reader.GetInt32(5);
                    receta.CantidadPrepacionDiaria = reader.GetInt32(6);
                    receta.Foto = reader.GetString(7);
                    receta.TipoReceta = reader.GetInt32(8);

                    CategoriaReceta categoriaReceta = new CategoriaReceta();

                    categoriaReceta.DescripcionCategoriaReceta = reader.GetString(9);

                    receta.CategoriaReceta = categoriaReceta;

                    recetas.Add(receta);

                }
                con.Close();

                return recetas;
            }
            catch (Exception)
            {
                return recetas;
            }
        }
    }
}
