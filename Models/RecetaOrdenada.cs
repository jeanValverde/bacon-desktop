using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class RecetaOrdenada
    {
        private int idRecetaOrdenada;
        private int cantidad;
        private int valor;
        private Receta receta;
        private Orden orden;

        public RecetaOrdenada()
        {

        }

        public RecetaOrdenada(int idRecetaOrdenada, int cantidad, int valor, Receta receta, Orden orden)
        {
            this.idRecetaOrdenada = idRecetaOrdenada;
            this.cantidad = cantidad;
            this.valor = valor;
            this.receta = receta;
            this.orden = orden;
        }

        public int IdRecetaOrdenada { get => idRecetaOrdenada; set => idRecetaOrdenada = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Valor { get => valor; set => valor = value; }
        public Receta Receta { get => receta; set => receta = value; }
        public Orden Orden { get => orden; set => orden = value; }

        public class EqualityComparer : IEqualityComparer<RecetaOrdenada>
        {

            public bool Equals(RecetaOrdenada x, RecetaOrdenada y)
            {
                return x.idRecetaOrdenada == y.idRecetaOrdenada;
            }

            public int GetHashCode(RecetaOrdenada obj)
            {
                return obj.idRecetaOrdenada.GetHashCode();
            }
        }
    }
}
