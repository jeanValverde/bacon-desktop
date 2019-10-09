using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class BoletaControl
    {
        private int idBoletaControl;
        private ControlCaja controlCaja;
        private Boleta boleta;
        
        public BoletaControl()
        {

        }

        public BoletaControl(int idBoletaControl, ControlCaja controlCaja, Boleta boleta)
        {
            this.idBoletaControl = idBoletaControl;
            this.controlCaja = controlCaja;
            this.boleta = boleta;
        }

        public int IdBoletaControl { get => idBoletaControl; set => idBoletaControl = value; }
        public ControlCaja ControlCaja { get => controlCaja; set => controlCaja = value; }
        public Boleta Boleta { get => boleta; set => boleta = value; }

        public class EqualityComparer : IEqualityComparer<BoletaControl>
        {

            public bool Equals(BoletaControl x, BoletaControl y)
            {
                return x.idBoletaControl == y.idBoletaControl;
            }

            public int GetHashCode(BoletaControl obj)
            {
                return obj.idBoletaControl.GetHashCode();
            }
        }
    }
}
