using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class MedioPago
    {
        private int idMedioPago;
        private string descripcion;

        public MedioPago()
        {

        }

        public MedioPago(int idMedioPago, string descripcion)
        {
            this.idMedioPago = idMedioPago;
            this.descripcion = descripcion;
        }

        public int IdMedioPago { get => idMedioPago; set => idMedioPago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public class EqualityComparer : IEqualityComparer<MedioPago>
        {

            public bool Equals(MedioPago x, MedioPago y)
            {
                return x.idMedioPago == y.idMedioPago;
            }

            public int GetHashCode(MedioPago obj)
            {
                return obj.idMedioPago.GetHashCode();
            }
        }
    }
}
