using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class BarService
    {
        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public BarService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }

        //Obtener las notificaciones de ordenes de Bar
        public List<OrdenBar> getOrdenesByEstadoEnBar()
        {
            List<OrdenBar> ordenesBar = new List<OrdenBar>();


            try
            {

                cmd.CommandText = "PACKAGE_ORDEN.PR_LISTAR_ORDENES_EN_BAR";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("CURSOR_ORDENES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {

                    Orden orden = new Orden();

                    orden.IdOrden = reader.GetInt32(0);
                    orden.Descripcion = reader.GetString(1);
                    orden.TiempoPreparacion = reader.GetInt32(2);

                    Cliente cliente = new Cliente();

                    Mesa mesa = new Mesa();

                    mesa.NumeroMesa = reader.GetInt32(3);

                    cliente.Mesa = mesa;

                    orden.Cliente = cliente;

                    orden.FechaCompleta = reader.GetString(4);
                    orden.Fecha = reader.GetString(5);

                    orden.Hora = reader.GetString(6);


                    OrdenBar ordenBar = new OrdenBar();

                    List<RecetaOrdenada> recetasOrdeadas = new List<RecetaOrdenada>();

                    ordenBar.Orden = orden;

                    ordenBar.RecetaOrdenada = recetasOrdeadas;

                    ordenesBar.Add(ordenBar);

                }

                con.Close();

                return ordenesBar;


            }
            catch (Exception)
            {
                OrdenBar ordenBar = new OrdenBar();

                Orden orden = new Orden();
                orden.Descripcion = "Error: ENTTRO EN EL CASH DE PROCEDURE";
                ordenBar.Orden = orden;

                ordenesBar.Add(ordenBar);
                ordenesBar.Add(ordenBar);
                ordenesBar.Add(ordenBar);
                ordenesBar.Add(ordenBar);

                return ordenesBar;
            }

        }

        public List<RecetaCantidad> obtenerRecetasWithCantidadBar(List<OrdenBar> ordenes)
        {
            List<RecetaCantidad> listaReceta = new List<RecetaCantidad>();

            List<Receta> recetas = new List<Receta>();

            List<RecetaOrdenada> recetasOrdenada = new List<RecetaOrdenada>();

            //obtener las recetas
            foreach (var d in ordenes)
            {
                foreach (var rect in d.RecetaOrdenada)
                {
                    recetas.Add(rect.Receta);
                    RecetaOrdenada recetaOrdenada = new RecetaOrdenada();
                    recetaOrdenada = rect;
                    recetasOrdenada.Add(recetaOrdenada);
                }

            }

            List<Receta> recetaSinRepetir = new List<Receta>();

            foreach (var rece in recetas)
                if (!recetaSinRepetir.Contains(rece, new Receta.EqualityComparer()))
                    recetaSinRepetir.Add(rece);

            foreach (var item in recetaSinRepetir)
            {
                RecetaCantidad recetaCantidad = new RecetaCantidad();

                recetaCantidad.Receta = item;
                recetaCantidad.Cantidad = calcularCantidadRecetasBar(ordenes, item.IdReceta); ;
                listaReceta.Add(recetaCantidad);
            }


            return listaReceta;
        }

        private int calcularCantidadRecetasBar(List<OrdenBar> ordenes, int idReceta)
        {

            int cantidad = 0;

            List<RecetaOrdenada> recetasOrdenada = new List<RecetaOrdenada>();

            foreach (var item in ordenes)
            {

                foreach (var i in item.RecetaOrdenada)
                {
                    if (i.Receta.IdReceta == idReceta)
                    {
                        cantidad += i.Cantidad;
                    }
                }

            }

            return cantidad;
        }

        public List<OrdenBar> completarOrdenBar(List<OrdenBar> ordenes)
        {
            List<OrdenBar> ordenesFinal = new List<OrdenBar>();


            //TRAE TODO DE LA BASE DE DATOS 
            List<RecetaOrdenada> recetaOrdenada = this.getRecetasOrdenadasByIdOrdenBar();



            foreach (var item in ordenes)
            {
                //PARA AREGAR A LA LISTA DE UNA ORDEN 
                List<RecetaOrdenada> recetaOrdenadaBar = new List<RecetaOrdenada>();

                //LA ORDEN DE COCINA 
                OrdenBar ord = new OrdenBar();

                ord.Orden = item.Orden;

                foreach (var recetas in recetaOrdenada)
                {
                    if (recetas.Orden.IdOrden == item.Orden.IdOrden)
                    {
                        recetaOrdenadaBar.Add(recetas);
                    }
                }

                ord.RecetaOrdenada = recetaOrdenadaBar;

                ordenesFinal.Add(ord);
            }

            return ordenesFinal;
        }


        public List<RecetaOrdenada> getRecetasOrdenadasByIdOrdenBar()
        {

            cmd.CommandText = "PACKAGE_ORDEN.PR_LIST_RECTAS_ORDENS_ALL";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("CURSOR_ORDENES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<RecetaOrdenada> recetasOrdenadas = new List<RecetaOrdenada>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();

                foreach (var item in reader)
                {

                    RecetaOrdenada recetaOrdenada = new RecetaOrdenada();

                    recetaOrdenada.IdRecetaOrdenada = reader.GetInt32(0);

                    Receta receta = new Receta();
                    receta.NombreReceta = reader.GetString(1);



                    recetaOrdenada.Cantidad = reader.GetInt32(2);

                    Orden orden = new Orden();

                    orden.IdOrden = reader.GetInt32(3);

                    receta.IdReceta = reader.GetInt32(4);

                    recetaOrdenada.Receta = receta;

                    recetaOrdenada.Orden = orden;



                    recetasOrdenadas.Add(recetaOrdenada);

                }

                con.Close();




                return recetasOrdenadas;


            }
            catch (Exception ex)
            {
                RecetaOrdenada recetaOrdenada = new RecetaOrdenada();


                Receta receta = new Receta();

                receta.NombreReceta = ex.Message;

                recetaOrdenada.Cantidad = 1;

                recetaOrdenada.Receta = receta;

                recetasOrdenadas.Add(recetaOrdenada);

                return recetasOrdenadas;
            }

        }

        //receta by id
        public Receta getRecetaByIdBar(Int32 id)
        {
            cmd.CommandText = "PACKAGE_RECETA.RECETA_BY_ID";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_RECETA", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("P_RECETAS_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


            Receta receta = new Receta();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

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

                    categoriaReceta.IdCategoriaReceta = reader.GetInt32(9);
                    categoriaReceta.DescripcionCategoriaReceta = reader.GetString(10);

                    receta.CategoriaReceta = categoriaReceta;


                    break;
                }

                con.Close();

                return receta;


            }
            catch (Exception)
            {
                return receta;
            }
        }



        //receta by id
        public List<Ingrediente> getIngredientesByIdRecetaBar(Int32 id)
        {
            cmd.CommandText = "PACKAGE_INGREDIENTE.FILTRO_INGREDIENTE_RECETA";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_RECETA", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("P_INGREDIENTES_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


            List<Ingrediente> ingredientes = new List<Ingrediente>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Ingrediente ingrediente = new Ingrediente();
                    Insumo insumo = new Insumo();


                    insumo.IdInsumo = reader.GetInt32(0);
                    insumo.NombreInusmo = reader.GetString(1);
                    insumo.DescripcionInusmo = reader.GetString(2);
                    insumo.StockInsumo = reader.GetInt32(3);
                    insumo.UnidadMedidaInsumo = reader.GetString(4);
                    insumo.MinStockInsumo = reader.GetInt32(5);
                    insumo.MaxStockInsumo = reader.GetInt32(6);
                    insumo.Foto = reader.GetString(7);

                    ingrediente.IdIngrediente = reader.GetInt32(8);
                    Receta receta = new Receta();
                    ingrediente.Receta = receta;
                    ingrediente.Cantidad = reader.GetInt32(9);

                    ingrediente.Insumo = insumo;

                    ingredientes.Add(ingrediente);
                }

                con.Close();

                return ingredientes;


            }
            catch (Exception)
            {
                return ingredientes;
            }
        }


        //eliminar con confirmacion 
        public int completarOrdenBar(int idOrden)
        {
            cmd.CommandText = "PACKAGE_ORDEN.PR_COMPLETAR_ORDEN";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_ORDEN", OracleDbType.Int32).Value = idOrden;

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


        //insertar Notificacion
        public int insertarNotificacionBar(Notificacion notificacion)
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_INSERTAR_NOTIFICACION";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_DESCRIPCION", OracleDbType.NVarchar2).Value = notificacion.Descripcion;

            cmd.Parameters.Add("P_ID_ROL", OracleDbType.Int32).Value = notificacion.Rol.Id_rol;

            cmd.Parameters.Add("P_ASUNTO", OracleDbType.NVarchar2).Value = notificacion.Asunto;

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
