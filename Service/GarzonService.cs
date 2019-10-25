using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Service
{
    public class GarzonService
    {

        private ConnectionBacon connectionBacon;
        private OracleConnection con;
        private OracleCommand cmd;


        //siempre instacion los accesos a datos 
        public GarzonService()
        {
            //instacia la conexion a la base de datos  
            connectionBacon = new ConnectionBacon();

            // obtenemos a conexion 
            con = connectionBacon.Connection();

            //para crear hacer sentencias o llamarlas    
            cmd = con.CreateCommand();
        }

        //Obtener las notificaciones de ordenes de Bar
        public List<OrdenBar> getOrdenesByEstadoEnBarGarzon()
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
               

                return ordenesBar;
            }

        }

        public List<OrdenBar> completarOrdenBarGarzon(List<OrdenBar> ordenes)
        {
            List<OrdenBar> ordenesFinal = new List<OrdenBar>();


            //TRAE TODO DE LA BASE DE DATOS 
            List<RecetaOrdenada> recetaOrdenada = this.getRecetasOrdenadasByIdOrdenBarGarzon();



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

        public List<RecetaOrdenada> getRecetasOrdenadasByIdOrdenBarGarzon()
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

        //eliminar con confirmacion 
        public int completarOrdenBarGarzonConfirmacion(int idOrden)
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


        //Obtenemos las notificaciones de bar hacia el garzon
        public List<Notificacion> getNotificacionDeBarGarzon()
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_LISTAR_DE_BAR";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACIONES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Notificacion> notificaciones = new List<Notificacion>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Notificacion notificacion = new Notificacion();

                    notificacion.IdNotificacion = reader.GetInt32(0);
                    notificacion.Descripcion = reader.GetString(1);
                    notificacion.Estado = reader.GetInt32(2);
                    Rol rol = new Rol();
                    rol.Id_rol = reader.GetInt32(3);
                    notificacion.Rol = rol;
                    notificacion.Fecha = reader.GetDateTime(4);
                    notificacion.Asunto = reader.GetString(5);

                    notificaciones.Add(notificacion);

                }

                con.Close();

                return notificaciones;


            }
            catch (Exception)
            {
                return notificaciones;
            }
        }

        public List<Notificacion> getNotificacionParaBarGarzon()
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_LISTAR_PARA_BAR";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACIONES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Notificacion> notificaciones = new List<Notificacion>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Notificacion notificacion = new Notificacion();

                    notificacion.IdNotificacion = reader.GetInt32(0);
                    notificacion.Descripcion = reader.GetString(1);
                    notificacion.Estado = reader.GetInt32(2);
                    Rol rol = new Rol();
                    rol.Id_rol = reader.GetInt32(3);
                    notificacion.Rol = rol;
                    notificacion.Fecha = reader.GetDateTime(4);
                    notificacion.Asunto = reader.GetString(5);

                    notificaciones.Add(notificacion);

                }

                con.Close();

                return notificaciones;


            }
            catch (Exception)
            {
                return notificaciones;
            }
        }

        public List<Notificacion> obtenerTodasNotificacionesOrdenFechaBarGarzon(List<Notificacion> de, List<Notificacion> para)
        {
            List<Notificacion> notificacions = new List<Notificacion>();

            foreach (var item in de)
            {
                notificacions.Add(item);
            }

            foreach (var item in para)
            {
                notificacions.Add(item);
            }

            notificacions = notificacions.OrderByDescending(o => o.Fecha).ToList();

            return notificacions;

        }

        public int cambiarEstadoNotificacionBarGarzon(int idNotificacion)
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_SET_ESTADO_NOTIFY";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_NOTIFICACION", OracleDbType.Int32).Value = idNotificacion;

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



        //Notificaciones Cocina
        public List<Notificacion> getNotificacionDeCocinaGarzon()
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_LISTAR_DE_COCINA";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACIONES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Notificacion> notificaciones = new List<Notificacion>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Notificacion notificacion = new Notificacion();

                    notificacion.IdNotificacion = reader.GetInt32(0);
                    notificacion.Descripcion = reader.GetString(1);
                    notificacion.Estado = reader.GetInt32(2);
                    Rol rol = new Rol();
                    rol.Id_rol = reader.GetInt32(3);
                    notificacion.Rol = rol;
                    notificacion.Fecha = reader.GetDateTime(4);
                    notificacion.Asunto = reader.GetString(5);

                    notificaciones.Add(notificacion);

                }

                con.Close();

                return notificaciones;


            }
            catch (Exception)
            {
                return notificaciones;
            }
        }



        //
        public List<Notificacion> getNotificacionParaCocinaGarzon()
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_LISTAR_PARA_COCINA";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACIONES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Notificacion> notificaciones = new List<Notificacion>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Notificacion notificacion = new Notificacion();

                    notificacion.IdNotificacion = reader.GetInt32(0);
                    notificacion.Descripcion = reader.GetString(1);
                    notificacion.Estado = reader.GetInt32(2);
                    Rol rol = new Rol();
                    rol.Id_rol = reader.GetInt32(3);
                    notificacion.Rol = rol;
                    notificacion.Fecha = reader.GetDateTime(4);
                    notificacion.Asunto = reader.GetString(5);

                    notificaciones.Add(notificacion);

                }

                con.Close();

                return notificaciones;


            }
            catch (Exception)
            {
                return notificaciones;
            }
        }



        public List<Notificacion> obtenerTodasNotificacionesOrdenFechaCocinaGarzon(List<Notificacion> de, List<Notificacion> para)
        {
            List<Notificacion> notificacions = new List<Notificacion>();

            foreach (var item in de)
            {
                notificacions.Add(item);
            }

            foreach (var item in para)
            {
                notificacions.Add(item);
            }

            notificacions = notificacions.OrderByDescending(o => o.Fecha).ToList();

            return notificacions;

        }


        //UPDATE NOTIFY ESTADO 
        public int cambiarEstadoNotificacionCocinaGarzon(int idNotificacion)
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_SET_ESTADO_NOTIFY";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_NOTIFICACION", OracleDbType.Int32).Value = idNotificacion;

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


        //Metodos de garzon
        public List<Notificacion> getNotificacionDeGarzon()
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_LISTAR_DE_GARZON";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACIONES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Notificacion> notificaciones = new List<Notificacion>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Notificacion notificacion = new Notificacion();

                    notificacion.IdNotificacion = reader.GetInt32(0);
                    notificacion.Descripcion = reader.GetString(1);
                    notificacion.Estado = reader.GetInt32(2);
                    Rol rol = new Rol();
                    rol.Id_rol = reader.GetInt32(3);
                    notificacion.Rol = rol;
                    notificacion.Fecha = reader.GetDateTime(4);
                    notificacion.Asunto = reader.GetString(5);

                    notificaciones.Add(notificacion);

                }

                con.Close();

                return notificaciones;


            }
            catch (Exception)
            {
                return notificaciones;
            }
        }

        public List<Notificacion> getNotificacionParaGarzon()
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_LISTAR_PARA_GARZON";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_NOTIFICACIONES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            List<Notificacion> notificaciones = new List<Notificacion>();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {

                    Notificacion notificacion = new Notificacion();

                    notificacion.IdNotificacion = reader.GetInt32(0);
                    notificacion.Descripcion = reader.GetString(1);
                    notificacion.Estado = reader.GetInt32(2);
                    Rol rol = new Rol();
                    rol.Id_rol = reader.GetInt32(3);
                    notificacion.Rol = rol;
                    notificacion.Fecha = reader.GetDateTime(4);
                    notificacion.Asunto = reader.GetString(5);

                    notificaciones.Add(notificacion);

                }

                con.Close();

                return notificaciones;


            }
            catch (Exception)
            {
                return notificaciones;
            }
        }

        public List<Notificacion> obtenerTodasNotificacionesOrdenFechaGarzonEnviadas(List<Notificacion> de, List<Notificacion> para)
        {
            List<Notificacion> notificacions = new List<Notificacion>();

            foreach (var item in de)
            {
                notificacions.Add(item);
            }

            foreach (var item in para)
            {
                notificacions.Add(item);
            }

            notificacions = notificacions.OrderByDescending(o => o.Fecha).ToList();

            return notificacions;

        }

        public int cambiarEstadoNotificacionGarzonEnviadas(int idNotificacion)
        {
            cmd.CommandText = "PACKAGE_NOTIFICACION.PR_SET_ESTADO_NOTIFY";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_NOTIFICACION", OracleDbType.Int32).Value = idNotificacion;

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
