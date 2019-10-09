using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Pedido
    {
        private int idPedido;
        private DateTime fechaPedido;
        private int valorPedido;
        private int ivaPedido;
        private int totalPedido;
        private string detallePedido;
        private int revisadoFinanzas;
        private string motivoRechazo;
        private EstadoPedido estadoPedido;
        private Proveedor proveedor;


        public Pedido()
        {

        }

        public Pedido(int idPedido, DateTime fechaPedido, int valorPedido, int ivaPedido, int totalPedido, string detallePedido, int revisadoFinanzas, string motivoRechazo, EstadoPedido estadoPedido, Proveedor proveedor)
        {
            this.idPedido = idPedido;
            this.fechaPedido = fechaPedido;
            this.valorPedido = valorPedido;
            this.ivaPedido = ivaPedido;
            this.totalPedido = totalPedido;
            this.detallePedido = detallePedido;
            this.revisadoFinanzas = revisadoFinanzas;
            this.motivoRechazo = motivoRechazo;
            this.estadoPedido = estadoPedido;
            this.proveedor = proveedor;
        }

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }
        public int ValorPedido { get => valorPedido; set => valorPedido = value; }
        public int IvaPedido { get => ivaPedido; set => ivaPedido = value; }
        public int TotalPedido { get => totalPedido; set => totalPedido = value; }
        public string DetallePedido { get => detallePedido; set => detallePedido = value; }
        public int RevisadoFinanzas { get => revisadoFinanzas; set => revisadoFinanzas = value; }
        public string MotivoRechazo { get => motivoRechazo; set => motivoRechazo = value; }
        public EstadoPedido EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }


        public class EqualityComparer : IEqualityComparer<Pedido>
        {

            public bool Equals(Pedido x, Pedido y)
            {
                return x.idPedido == y.idPedido;
            }

            public int GetHashCode(Pedido obj)
            {
                return obj.idPedido.GetHashCode();
            }
        }


    }
}
