using bacon_desktop.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public List<OrdenGarzon> listarOrdenesListarParaServir()
        {
            List<OrdenGarzon> ordenesGarzon = new List<OrdenGarzon>();

            try
            {

                cmd.CommandText = "PACKAGE_ORDEN.PR_LISTAR_ORDENES_EN_LISTAS";

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
                  // orden.EstadoOrden.IdEstadoOrden = reader.GetInt32(7);

                    OrdenGarzon ordenGarzon = new OrdenGarzon();

                    List<RecetaOrdenada> recetasOrdeadas = new List<RecetaOrdenada>();
                    ordenGarzon.EstadoOrden = reader.GetInt32(7);
                    ordenGarzon.Orden = orden;
                    ordenGarzon.RecetaOrdenada = recetasOrdeadas;

                    ordenesGarzon.Add(ordenGarzon);

                }

                con.Close();

                return ordenesGarzon;


            }
            catch (Exception)
            {
                OrdenGarzon ordenGarzon = new OrdenGarzon();

                Orden orden = new Orden();
                orden.Descripcion = "Error: ENTTRO EN EL CASH DE PROCEDURE";
                ordenGarzon.Orden = orden;

                ordenesGarzon.Add(ordenGarzon);
                ordenesGarzon.Add(ordenGarzon);
                ordenesGarzon.Add(ordenGarzon);
                ordenesGarzon.Add(ordenGarzon);

                return ordenesGarzon;
            }

        }

        public List<RecetaCantidad> obtenerRecetasWithCantidad(List<OrdenGarzon> ordenes)
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
                recetaCantidad.Cantidad = calcularCantidadRecetas(ordenes, item.IdReceta); ;
                listaReceta.Add(recetaCantidad);
            }


            return listaReceta;
        }

        private int calcularCantidadRecetas(List<OrdenGarzon> ordenes, int idReceta)
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

        public List<OrdenGarzon> servirOrden(List<OrdenGarzon> ordenes)
        {
            List<OrdenGarzon> ordenesFinal = new List<OrdenGarzon>();


            //TRAE TODO DE LA BASE DE DATOS 
            List<RecetaOrdenada> recetaOrdenada = this.getRecetasOrdenadasByIdOrden();



            foreach (var item in ordenes)
            {
                //PARA AREGAR A LA LISTA DE UNA ORDEN 
                List<RecetaOrdenada> recetaOrdenadaCocina = new List<RecetaOrdenada>();

                //LA ORDEN DE COCINA 
                OrdenGarzon ord = new OrdenGarzon();

                ord.Orden = item.Orden;
                ord.EstadoOrden = item.EstadoOrden;

                foreach (var recetas in recetaOrdenada)
                {
                    if (recetas.Orden.IdOrden == item.Orden.IdOrden)
                    {
                        recetaOrdenadaCocina.Add(recetas);
                    }
                }

                ord.RecetaOrdenada = recetaOrdenadaCocina;

                ordenesFinal.Add(ord);
            }

            return ordenesFinal;
        }


        public List<RecetaOrdenada> getRecetasOrdenadasByIdOrden()
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

       
        public Orden getOrdenById(Int32 id)
        {
            cmd.CommandText = "PACKAGE_ORDEN.ORDEN_BY_ID";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_ID_ORDEN", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("P_ORDEN_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


            Orden orden = new Orden();

            try
            {

                OracleDataReader reader = cmd.ExecuteReader();


                foreach (var item in reader)
                {
                    orden.IdOrden = reader.GetInt32(0);
                    orden.Descripcion = reader.GetString(1);
                    orden.SubTotal = reader.GetInt32(2);
                    orden.Iva = reader.GetInt32(3);
                    orden.TotalOrden = reader.GetInt32(4);
                    orden.TiempoPreparacion = reader.GetInt32(5);
                    orden.MotivoAnulacion = reader.GetString(6);
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = reader.GetInt32(7);
                    orden.Cliente = cliente;
                    EstadoOrden estadoOrden = new EstadoOrden();
                    estadoOrden.IdEstadoOrden = reader.GetInt32(8);
                    orden.EstadoOrden = estadoOrden;
                    orden.TipoOrden = reader.GetInt32(9);
                    orden.FechaCompleta = reader.GetString(10);

                    break;
                }

                con.Close();

                return orden;


            }
            catch (Exception)
            {
                return orden;
            }
        }



        //eliminar con confirmacion 
        public int servirOrden(int idOrden)
        {
            cmd.CommandText = "PACKAGE_ORDEN.PR_SERVIR_ORDEN";

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

        public int anularOrden(int idOrden,String motivo)
        {
            cmd.CommandText = "PACKAGE_ORDEN.PR_ANULAR_ORDEN";

            cmd.CommandType = CommandType.StoredProcedure;
            System.Console.WriteLine(motivo);
            cmd.Parameters.Add("P_ID_ORDEN", OracleDbType.Int32).Value = idOrden;
            cmd.Parameters.Add("P_MOTIVO", OracleDbType.NVarchar2).Value = motivo;

            cmd.Parameters.Add("V_EXITO", OracleDbType.Int32).Direction = ParameterDirection.Output;

            try
            {

                cmd.ExecuteNonQuery();

                int result = int.Parse(cmd.Parameters["V_EXITO"].Value.ToString());

                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return -1;
            }
        }


        //insertar Notificacion
        public int insertarNotificacion(Notificacion notificacion)
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
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }



    }
}
