using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class OrdenCocina
    {
        private Orden orden;
        private List<RecetaOrdenada> recetaOrdenada;

        public OrdenCocina()
        {

        }

        public OrdenCocina(Orden orden, List<RecetaOrdenada> recetaOrdenada)
        {
            this.orden = orden;
            this.recetaOrdenada = recetaOrdenada;
        }

        public Orden Orden { get => orden; set => orden = value; }
        public List<RecetaOrdenada> RecetaOrdenada { get => recetaOrdenada; set => recetaOrdenada = value; }
    }
}
