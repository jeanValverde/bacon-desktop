using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class RecetaCocina
    {
        private Receta receta;
        private int cantidad;

        public RecetaCocina()
        {

        }

        public RecetaCocina(Receta receta, int cantidad)
        {
            this.receta = receta;
            this.cantidad = cantidad;
        }

        public Receta Receta { get => receta; set => receta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
