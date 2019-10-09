using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class InsumoProveedor
    {
        private int idInsumoProveedor;
        private int precio;
        private Insumo insumo;
        private Proveedor proveedor;

        public InsumoProveedor()
        {

        }

        public InsumoProveedor(int idInsumoProveedor, int precio, Insumo insumo, Proveedor proveedor)
        {
            this.idInsumoProveedor = idInsumoProveedor;
            this.precio = precio;
            this.insumo = insumo;
            this.proveedor = proveedor;
        }

        public int IdInsumoProveedor { get => idInsumoProveedor; set => idInsumoProveedor = value; }
        public int Precio { get => precio; set => precio = value; }
        public Insumo Insumo { get => insumo; set => insumo = value; }
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }


        public class EqualityComparer : IEqualityComparer<InsumoProveedor>
        {

            public bool Equals(InsumoProveedor x, InsumoProveedor y)
            {
                return x.idInsumoProveedor == y.idInsumoProveedor;
            }

            public int GetHashCode(InsumoProveedor obj)
            {
                return obj.idInsumoProveedor.GetHashCode();
            }
        }

    }
}
