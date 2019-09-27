using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Rol
    {
        private int id_rol;
        private string descripcion_rol;

        public Rol()
        {
        }

        public Rol(int id_rol, string descripcion_rol)
        {
            this.id_rol = id_rol;
            this.descripcion_rol = descripcion_rol;
        }

        public int Id_rol
        {
            get
            {
                return id_rol;
            }

            set
            {
                id_rol = value;
            }
        }

        public string Descripcion_rol
        {
            get
            {
                return descripcion_rol;
            }

            set
            {
                descripcion_rol = value;
            }
        }
    }
}
