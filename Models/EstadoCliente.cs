using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class EstadoCliente
    {
        private int idEstadoCliente;
        private int descripcionEstado;

        public int IdEstadoCliente { get => idEstadoCliente; set => idEstadoCliente = value; }
        public int DescripcionEstado { get => descripcionEstado; set => descripcionEstado = value; }

        public EstadoCliente(int idEstadoCliente, int descripcionEstado)
        {
            this.idEstadoCliente = idEstadoCliente;
            this.descripcionEstado = descripcionEstado;
        }

        public EstadoCliente()
        {

        }

        public class EqualityComparer : IEqualityComparer<EstadoCliente>
        {

            public bool Equals(EstadoCliente x, EstadoCliente y)
            {
                return x.idEstadoCliente == y.idEstadoCliente;
            }

            public int GetHashCode(EstadoCliente obj)
            {
                return obj.idEstadoCliente.GetHashCode();
            }
        }


    }
}
