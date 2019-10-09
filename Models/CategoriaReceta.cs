using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class CategoriaReceta
    {
        private int idCategoriaReceta;
        private string descripcionCategoriaReceta;
        private int cantidadRecetasDias;

        public CategoriaReceta()
        {

        }

        public CategoriaReceta(int idCategoriaReceta, string descripcionCategoriaReceta, int cantidadRecetasDias)
        {
            this.idCategoriaReceta = idCategoriaReceta;
            this.descripcionCategoriaReceta = descripcionCategoriaReceta;
            this.cantidadRecetasDias = cantidadRecetasDias;
        }

        public int IdCategoriaReceta { get => idCategoriaReceta; set => idCategoriaReceta = value; }
        public string DescripcionCategoriaReceta { get => descripcionCategoriaReceta; set => descripcionCategoriaReceta = value; }
        public int CantidadRecetasDias { get => cantidadRecetasDias; set => cantidadRecetasDias = value; }

        public class EqualityComparer : IEqualityComparer<CategoriaReceta>
        {

            public bool Equals(CategoriaReceta x, CategoriaReceta y)
            {
                return x.idCategoriaReceta == y.idCategoriaReceta;
            }

            public int GetHashCode(CategoriaReceta obj)
            {
                return obj.idCategoriaReceta.GetHashCode();
            }
        }
    }
}
