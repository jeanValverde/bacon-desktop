using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class ControlCaja
    {
        private int idControlCaja;
        private DateTime fechaControlCaja;
        private int totalBoleta;
        private int utilidadBruta;
        private int montoFinal;
        private int montoInicial;
        private Personal personal;

        public ControlCaja()
        {

        }

        public ControlCaja(int idControlCaja, DateTime fechaControlCaja, int totalBoleta, int utilidadBruta, int montoFinal, int montoInicial, Personal personal)
        {
            this.idControlCaja = idControlCaja;
            this.fechaControlCaja = fechaControlCaja;
            this.totalBoleta = totalBoleta;
            this.utilidadBruta = utilidadBruta;
            this.montoFinal = montoFinal;
            this.montoInicial = montoInicial;
            this.personal = personal;
        }

        public int IdControlCaja { get => idControlCaja; set => idControlCaja = value; }
        public DateTime FechaControlCaja { get => fechaControlCaja; set => fechaControlCaja = value; }
        public int TotalBoleta { get => totalBoleta; set => totalBoleta = value; }
        public int UtilidadBruta { get => utilidadBruta; set => utilidadBruta = value; }
        public int MontoFinal { get => montoFinal; set => montoFinal = value; }
        public int MontoInicial { get => montoInicial; set => montoInicial = value; }
        public Personal Personal { get => personal; set => personal = value; }

        public class EqualityComparer : IEqualityComparer<ControlCaja>
        {

            public bool Equals(ControlCaja x, ControlCaja y)
            {
                return x.idControlCaja == y.idControlCaja;
            }

            public int GetHashCode(ControlCaja obj)
            {
                return obj.idControlCaja.GetHashCode();
            }
        }
    }
}
