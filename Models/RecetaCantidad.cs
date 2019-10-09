using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class RecetaCantidad
    {
        private Receta receta;
        private int cantidad;

        public RecetaCantidad()
        {

        }

        public RecetaCantidad(Receta receta, int cantidad)
        {
            this.receta = receta;
            this.cantidad = cantidad;
        }

        public Receta Receta { get => receta; set => receta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
