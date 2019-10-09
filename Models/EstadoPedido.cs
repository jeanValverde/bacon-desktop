using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class EstadoPedido
    {
        private int idEstadoPedido;
        private string descripcionEstadoPedido;

        public EstadoPedido()
        {

        }

        public EstadoPedido(int idEstadoPedido, string descripcionEstadoPedido)
        {
            this.idEstadoPedido = idEstadoPedido;
            this.descripcionEstadoPedido = descripcionEstadoPedido;
        }

        public int IdEstadoPedido { get => idEstadoPedido; set => idEstadoPedido = value; }
        public string DescripcionEstadoPedido { get => descripcionEstadoPedido; set => descripcionEstadoPedido = value; }

        public class EqualityComparer : IEqualityComparer<EstadoPedido>
        {

            public bool Equals(EstadoPedido x, EstadoPedido y)
            {
                return x.idEstadoPedido == y.idEstadoPedido;
            }

            public int GetHashCode(EstadoPedido obj)
            {
                return obj.idEstadoPedido.GetHashCode();
            }
        }

    }
}
