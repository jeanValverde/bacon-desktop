using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Proveedor
    {
        private int idProveedor;
        private string rutPrveedor;
        private string nombreProveedor;
        private string direccionProveedor;
        private string telefonoProveedor;
        private string contactoVenta;
        private string tipoProveedor;
        private string correoProveedor;
        private int celularProveedor;
        private string categoriaProveedor;

        public Proveedor()
        {

        }

        public Proveedor(int idProveedor, string rutPrveedor, string nombreProveedor, string direccionProveedor, string telefonoProveedor, string contactoVenta, string tipoProveedor, string correoProveedor, int celularProveedor, string categoriaProveedor)
        {
            this.idProveedor = idProveedor;
            this.rutPrveedor = rutPrveedor;
            this.nombreProveedor = nombreProveedor;
            this.direccionProveedor = direccionProveedor;
            this.telefonoProveedor = telefonoProveedor;
            this.contactoVenta = contactoVenta;
            this.tipoProveedor = tipoProveedor;
            this.correoProveedor = correoProveedor;
            this.celularProveedor = celularProveedor;
            this.categoriaProveedor = categoriaProveedor;
        }

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string RutPrveedor { get => rutPrveedor; set => rutPrveedor = value; }
        public string NombreProveedor { get => nombreProveedor; set => nombreProveedor = value; }
        public string DireccionProveedor { get => direccionProveedor; set => direccionProveedor = value; }
        public string TelefonoProveedor { get => telefonoProveedor; set => telefonoProveedor = value; }
        public string ContactoVenta { get => contactoVenta; set => contactoVenta = value; }
        public string TipoProveedor { get => tipoProveedor; set => tipoProveedor = value; }
        public string CorreoProveedor { get => correoProveedor; set => correoProveedor = value; }
        public int CelularProveedor { get => celularProveedor; set => celularProveedor = value; }
        public string CategoriaProveedor { get => categoriaProveedor; set => categoriaProveedor = value; }


        public class EqualityComparer : IEqualityComparer<Proveedor>
        {

            public bool Equals(Proveedor x, Proveedor y)
            {
                return x.idProveedor == y.idProveedor;
            }

            public int GetHashCode(Proveedor obj)
            {
                return obj.idProveedor.GetHashCode();
            }
        }

    }
}
