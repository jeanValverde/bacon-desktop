using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Insumo
    {
        private int idInsumo;
        private string nombreInusmo;
        private string descripcionInusmo;
        private int stockInsumo;
        private string unidadMedidaInsumo;
        private int minStockInsumo;
        private int maxStockInsumo;
        private string foto;

        public Insumo()
        {

        }

        public Insumo(int idInsumo, string nombreInusmo, string descripcionInusmo, int stockInsumo, string unidadMedidaInsumo, int minStockInsumo, int maxStockInsumo, string foto)
        {
            this.idInsumo = idInsumo;
            this.nombreInusmo = nombreInusmo;
            this.descripcionInusmo = descripcionInusmo;
            this.stockInsumo = stockInsumo;
            this.unidadMedidaInsumo = unidadMedidaInsumo;
            this.minStockInsumo = minStockInsumo;
            this.maxStockInsumo = maxStockInsumo;
            this.foto = foto;
        }

        public int IdInsumo { get => idInsumo; set => idInsumo = value; }
        public string NombreInusmo { get => nombreInusmo; set => nombreInusmo = value; }
        public string DescripcionInusmo { get => descripcionInusmo; set => descripcionInusmo = value; }
        public int StockInsumo { get => stockInsumo; set => stockInsumo = value; }
        public string UnidadMedidaInsumo { get => unidadMedidaInsumo; set => unidadMedidaInsumo = value; }
        public int MinStockInsumo { get => minStockInsumo; set => minStockInsumo = value; }
        public int MaxStockInsumo { get => maxStockInsumo; set => maxStockInsumo = value; }
        public string Foto { get => foto; set => foto = value; }

        public class EqualityComparer : IEqualityComparer<Insumo>
        {

            public bool Equals(Insumo x, Insumo y)
            {
                return x.idInsumo == y.idInsumo;
            }

            public int GetHashCode(Insumo obj)
            {
                return obj.idInsumo.GetHashCode();
            }
        }
    }
}
