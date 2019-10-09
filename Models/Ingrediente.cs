using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Ingrediente
    {
        private int idIngrediente;
        private int cantidad;
        private Receta receta;
        private Insumo insumo;

        public Ingrediente()
        {

        }

        public Ingrediente(int idIngrediente, int cantidad, Receta receta, Insumo insumo)
        {
            this.idIngrediente = idIngrediente;
            this.cantidad = cantidad;
            this.receta = receta;
            this.insumo = insumo;
        }

        public int IdIngrediente { get => idIngrediente; set => idIngrediente = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Receta Receta { get => receta; set => receta = value; }
        public Insumo Insumo { get => insumo; set => insumo = value; }

        public class EqualityComparer : IEqualityComparer<Ingrediente>
        {

            public bool Equals(Ingrediente x, Ingrediente y)
            {
                return x.idIngrediente == y.idIngrediente;
            }

            public int GetHashCode(Ingrediente obj)
            {
                return obj.idIngrediente.GetHashCode();
            }
        }
    }
}
