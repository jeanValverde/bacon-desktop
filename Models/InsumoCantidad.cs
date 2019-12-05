using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class InsumoCantidad
    {
        private Insumo insumo;
        private double cantidad;
        private double cantidadHaComprar;
        public InsumoCantidad()
        {

        }

        public InsumoCantidad(Insumo insumo, double cantidad, double cantidadHaComprar)
        {
            this.insumo = insumo;
            this.cantidad = cantidad;
            this.CantidadHaComprar = cantidadHaComprar;
        }

        public Insumo Insumo { get => insumo; set => insumo = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double CantidadHaComprar { get => cantidadHaComprar; set => cantidadHaComprar = value; }

        public class EqualityComparer : IEqualityComparer<InsumoCantidad>
        {

            public bool Equals(InsumoCantidad x, InsumoCantidad y)
            {
                return x.Insumo == y.Insumo;
            }

            public int GetHashCode(InsumoCantidad obj)
            {
                return obj.Insumo.GetHashCode();
            }
        }

    }
}
