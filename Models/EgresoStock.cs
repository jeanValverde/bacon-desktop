using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class EgresoStock
    {
        private int idEgresoStock;
        private int cantidad;
        private Insumo insumo;
        private DateTime fechaEgreso;

        public EgresoStock()
        {

        }

        public EgresoStock(int idEgresoStock, int cantidad, Insumo insumo, DateTime fechaEgreso)
        {
            this.idEgresoStock = idEgresoStock;
            this.cantidad = cantidad;
            this.insumo = insumo;
            this.fechaEgreso = fechaEgreso;
        }

        public int IdEgresoStock { get => idEgresoStock; set => idEgresoStock = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Insumo Insumo { get => insumo; set => insumo = value; }
        public DateTime FechaEgreso { get => fechaEgreso; set => fechaEgreso = value; }

        public class EqualityComparer : IEqualityComparer<EgresoStock>
        {

            public bool Equals(EgresoStock x, EgresoStock y)
            {
                return x.idEgresoStock == y.idEgresoStock;
            }

            public int GetHashCode(EgresoStock obj)
            {
                return obj.idEgresoStock.GetHashCode();
            }
        }
    }
}
