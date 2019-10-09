using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Mesa
    {
        private int idMesa;
        private int numeroMesa;
        private int cantidadAsientosMesa;
        private int estadoMesa;

        public Mesa(int idMesa, int numeroMesa, int cantidadAsientosMesa, int estadoMesa)
        {
            this.idMesa = idMesa;
            this.numeroMesa = numeroMesa;
            this.cantidadAsientosMesa = cantidadAsientosMesa;
            this.estadoMesa = estadoMesa;
        }

        public Mesa()
        {

        }

        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int NumeroMesa { get => numeroMesa; set => numeroMesa = value; }
        public int CantidadAsientosMesa { get => cantidadAsientosMesa; set => cantidadAsientosMesa = value; }
        public int EstadoMesa { get => estadoMesa; set => estadoMesa = value; }

        public class EqualityComparer : IEqualityComparer<Mesa>
        {

            public bool Equals(Mesa x, Mesa y)
            {
                return x.idMesa == y.idMesa;
            }

            public int GetHashCode(Mesa obj)
            {
                return obj.idMesa.GetHashCode();
            }
        }

    }
}
