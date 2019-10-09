using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Orden
    {
        private int idOrden;
        private string descripcion;
        private int subTotal;
        private int iva;
        private int totalOrden;
        private int tiempoPreparacion;
        private string motivoAnulacion;
        private Cliente cliente;
        private EstadoOrden estadoOrden;
        private int tipoOrden;

        //logical 
        private string fecha;
        private string hora;
        private string fechaCompleta;

        public Orden()
        {

        }

        public Orden(int idOrden, string descripcion, int subTotal, int iva, int totalOrden, int tiempoPreparacion, string motivoAnulacion, Cliente cliente, EstadoOrden estadoOrden, int tipoOrden, string fecha, string hora, string fechaCompleta)
        {
            this.idOrden = idOrden;
            this.descripcion = descripcion;
            this.subTotal = subTotal;
            this.iva = iva;
            this.totalOrden = totalOrden;
            this.tiempoPreparacion = tiempoPreparacion;
            this.motivoAnulacion = motivoAnulacion;
            this.cliente = cliente;
            this.estadoOrden = estadoOrden;
            this.tipoOrden = tipoOrden;
            this.fecha = fecha;
            this.hora = hora;
            this.fechaCompleta = fechaCompleta;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int SubTotal { get => subTotal; set => subTotal = value; }
        public int Iva { get => iva; set => iva = value; }
        public int TotalOrden { get => totalOrden; set => totalOrden = value; }
        public int TiempoPreparacion { get => tiempoPreparacion; set => tiempoPreparacion = value; }
        public string MotivoAnulacion { get => motivoAnulacion; set => motivoAnulacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public EstadoOrden EstadoOrden { get => estadoOrden; set => estadoOrden = value; }
        public int TipoOrden { get => tipoOrden; set => tipoOrden = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public string FechaCompleta { get => fechaCompleta; set => fechaCompleta = value; }

        public class EqualityComparer : IEqualityComparer<Orden>
        {

            public bool Equals(Orden x, Orden y)
            {
                return x.idOrden == y.idOrden;
            }

            public int GetHashCode(Orden obj)
            {
                return obj.idOrden.GetHashCode();
            }
        }
    }
}
