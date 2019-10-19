using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class OrdenGarzon
    {
        private Orden orden;
        private List<RecetaOrdenada> recetaOrdenada;
        private int estadoOrden;

        public OrdenGarzon()
        {

        }

        public OrdenGarzon(Orden orden, List<RecetaOrdenada> recetaOrdenada, int estadoOrden)
        {
            this.orden = orden;
            this.recetaOrdenada = recetaOrdenada;
            this.estadoOrden = estadoOrden;
        }

        public Orden Orden { get => orden; set => orden = value; }
        public List<RecetaOrdenada> RecetaOrdenada { get => recetaOrdenada; set => recetaOrdenada = value; }

        public int EstadoOrden { get => estadoOrden; set => estadoOrden = value; }
    }
}
