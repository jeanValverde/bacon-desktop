using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class InsumoPedidoProveedor
    {
        private int idInsumoPedidoProveedor;
        private int precioPedidoProveedor;
        private int precioTotalInsumoPedido;
        private int ivaInsumoPedido;
        private InsumoPedido InsumoPedido;
        private Pedido pedido;

        public InsumoPedidoProveedor()
        {

        }

        public InsumoPedidoProveedor(int idInsumoPedidoProveedor, int precioPedidoProveedor, int precioTotalInsumoPedido, int ivaInsumoPedido, InsumoPedido insumoPedido, Pedido pedido)
        {
            this.idInsumoPedidoProveedor = idInsumoPedidoProveedor;
            this.precioPedidoProveedor = precioPedidoProveedor;
            this.precioTotalInsumoPedido = precioTotalInsumoPedido;
            this.ivaInsumoPedido = ivaInsumoPedido;
            InsumoPedido = insumoPedido;
            this.pedido = pedido;
        }

        public int IdInsumoPedidoProveedor { get => idInsumoPedidoProveedor; set => idInsumoPedidoProveedor = value; }
        public int PrecioPedidoProveedor { get => precioPedidoProveedor; set => precioPedidoProveedor = value; }
        public int PrecioTotalInsumoPedido { get => precioTotalInsumoPedido; set => precioTotalInsumoPedido = value; }
        public int IvaInsumoPedido { get => ivaInsumoPedido; set => ivaInsumoPedido = value; }
        public InsumoPedido InsumoPedido1 { get => InsumoPedido; set => InsumoPedido = value; }
        public Pedido Pedido { get => pedido; set => pedido = value; }



        public class EqualityComparer : IEqualityComparer<InsumoPedidoProveedor>
        {

            public bool Equals(InsumoPedidoProveedor x, InsumoPedidoProveedor y)
            {
                return x.idInsumoPedidoProveedor == y.idInsumoPedidoProveedor;
            }

            public int GetHashCode(InsumoPedidoProveedor obj)
            {
                return obj.idInsumoPedidoProveedor.GetHashCode();
            }
        }

    }
}
