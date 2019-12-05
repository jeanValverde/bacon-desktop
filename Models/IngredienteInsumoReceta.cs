using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class IngredienteInsumoReceta
    {
        private int idInsumo;
        private int cantidad;
        private int cantidad_diaria;

        public IngredienteInsumoReceta()
        {

        }

        public IngredienteInsumoReceta(int idInsumo, int cantidad, int cantidad_diaria)
        {
            this.IdInsumo = idInsumo;
            this.Cantidad = cantidad;
            this.Cantidad_diaria = cantidad_diaria;
        }

        public int IdInsumo { get => idInsumo; set => idInsumo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Cantidad_diaria { get => cantidad_diaria; set => cantidad_diaria = value; }

        public override bool Equals(object obj)
        {
            return obj is IngredienteInsumoReceta receta &&
                   IdInsumo == receta.IdInsumo &&
                   Cantidad == receta.Cantidad &&
                   Cantidad_diaria == receta.Cantidad_diaria;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdInsumo, Cantidad, Cantidad_diaria);
        }
    }
}
