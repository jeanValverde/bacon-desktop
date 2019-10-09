using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class IngresoStock
    {
        private int idIngresoStock;
        private DateTime fechaIngreso;
        private DateTime fechaCaducidad;
        private int cantidad;
        private Pedido pedido;
        private Insumo insumo;
        private int estado;

        public IngresoStock()
        {

        }

        public IngresoStock(int idIngresoStock, DateTime fechaIngreso, DateTime fechaCaducidad, int cantidad, Pedido pedido, Insumo insumo, int estado)
        {
            this.idIngresoStock = idIngresoStock;
            this.fechaIngreso = fechaIngreso;
            this.fechaCaducidad = fechaCaducidad;
            this.cantidad = cantidad;
            this.pedido = pedido;
            this.insumo = insumo;
            this.estado = estado;
        }

        public int IdIngresoStock { get => idIngresoStock; set => idIngresoStock = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaCaducidad { get => fechaCaducidad; set => fechaCaducidad = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Pedido Pedido { get => pedido; set => pedido = value; }
        public Insumo Insumo { get => insumo; set => insumo = value; }
        public int Estado { get => estado; set => estado = value; }


        public class EqualityComparer : IEqualityComparer<IngresoStock>
        {

            public bool Equals(IngresoStock x, IngresoStock y)
            {
                return x.idIngresoStock == y.idIngresoStock;
            }

            public int GetHashCode(IngresoStock obj)
            {
                return obj.idIngresoStock.GetHashCode();
            }
        }

    }
}
