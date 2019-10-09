using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Receta
    {
        private int idReceta;
        private string nombreReceta;
        private string descripcionReceta;
        private int duracionPreparacion;
        private int disponibilidadReceta;
        private int precioReceta;
        private int cantidadPrepacionDiaria;
        private string foto;
        private int tipoReceta;
        private CategoriaReceta categoriaReceta;

        public Receta()
        {

        }

        public Receta(int idReceta, string nombreReceta, string descripcionReceta, int duracionPreparacion, int disponibilidadReceta, int precioReceta, int cantidadPrepacionDiaria, string foto, int tipoReceta, CategoriaReceta categoriaReceta)
        {
            this.idReceta = idReceta;
            this.nombreReceta = nombreReceta;
            this.descripcionReceta = descripcionReceta;
            this.duracionPreparacion = duracionPreparacion;
            this.disponibilidadReceta = disponibilidadReceta;
            this.precioReceta = precioReceta;
            this.cantidadPrepacionDiaria = cantidadPrepacionDiaria;
            this.foto = foto;
            this.tipoReceta = tipoReceta;
            this.categoriaReceta = categoriaReceta;
        }

        public int IdReceta { get => idReceta; set => idReceta = value; }
        public string NombreReceta { get => nombreReceta; set => nombreReceta = value; }
        public string DescripcionReceta { get => descripcionReceta; set => descripcionReceta = value; }
        public int DuracionPreparacion { get => duracionPreparacion; set => duracionPreparacion = value; }
        public int DisponibilidadReceta { get => disponibilidadReceta; set => disponibilidadReceta = value; }
        public int PrecioReceta { get => precioReceta; set => precioReceta = value; }
        public int CantidadPrepacionDiaria { get => cantidadPrepacionDiaria; set => cantidadPrepacionDiaria = value; }
        public string Foto { get => foto; set => foto = value; }
        public int TipoReceta { get => tipoReceta; set => tipoReceta = value; }
        public CategoriaReceta CategoriaReceta { get => categoriaReceta; set => categoriaReceta = value; }

        public class EqualityComparer : IEqualityComparer<Receta>
        {

            public bool Equals(Receta x, Receta y)
            {
                return x.idReceta == y.idReceta;
            }

            public int GetHashCode(Receta obj)
            {
                return obj.idReceta.GetHashCode();
            }
        }
    }
}
