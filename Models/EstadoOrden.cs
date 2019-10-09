using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class EstadoOrden
    {
        private int idEstadoOrden;
        private string descripcionEstadoOrden;


        public EstadoOrden()
        {

        }

        public EstadoOrden(int idEstadoOrden, string descripcionEstadoOrden)
        {
            this.idEstadoOrden = idEstadoOrden;
            this.descripcionEstadoOrden = descripcionEstadoOrden;
        }

        public int IdEstadoOrden { get => idEstadoOrden; set => idEstadoOrden = value; }
        public string DescripcionEstadoOrden { get => descripcionEstadoOrden; set => descripcionEstadoOrden = value; }

        public class EqualityComparer : IEqualityComparer<EstadoOrden>
        {

            public bool Equals(EstadoOrden x, EstadoOrden y)
            {
                return x.idEstadoOrden == y.idEstadoOrden;
            }

            public int GetHashCode(EstadoOrden obj)
            {
                return obj.idEstadoOrden.GetHashCode();
            }
        }
    }
}
