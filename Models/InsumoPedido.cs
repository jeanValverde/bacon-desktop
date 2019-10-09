using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class InsumoPedido
    {
        private int idInsumoPedido;
        private int cantidadInsumo;
        private int estadoInsumoPedido;
        private Insumo insumo;


        public InsumoPedido()
        {

        }

        public InsumoPedido(int idInsumoPedido, int cantidadInsumo, int estadoInsumoPedido, Insumo insumo)
        {
            this.idInsumoPedido = idInsumoPedido;
            this.cantidadInsumo = cantidadInsumo;
            this.estadoInsumoPedido = estadoInsumoPedido;
            this.insumo = insumo;
        }

        public int IdInsumoPedido { get => idInsumoPedido; set => idInsumoPedido = value; }
        public int CantidadInsumo { get => cantidadInsumo; set => cantidadInsumo = value; }
        public int EstadoInsumoPedido { get => estadoInsumoPedido; set => estadoInsumoPedido = value; }
        public Insumo Insumo { get => insumo; set => insumo = value; }

        public class EqualityComparer : IEqualityComparer<InsumoPedido>
        {

            public bool Equals(InsumoPedido x, InsumoPedido y)
            {
                return x.idInsumoPedido == y.idInsumoPedido;
            }

            public int GetHashCode(InsumoPedido obj)
            {
                return obj.idInsumoPedido.GetHashCode();
            }
        }

    }
}
