using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Personal
    {
        private int idPersonal;
        private string rut_personal;
        private string nombres_personal;
        private string ape_paterno_personal;
        private string ape_materno_personal;
        private DateTime fecha_nacimiento_personal;
        private string celular_personal;
        private string correo_personal;
        private string contrasena_personal;
        private int estado_personal;
        private Rol rol;

        public Personal(int idPersonal, string rut_personal, string nombres_personal, string ape_paterno_personal, string ape_materno_personal, DateTime fecha_nacimiento_personal, string celular_personal, string correo_personal, string contrasena_personal, int estado_personal, Rol rol)
        {
            this.idPersonal = idPersonal;
            this.rut_personal = rut_personal;
            this.nombres_personal = nombres_personal;
            this.ape_paterno_personal = ape_paterno_personal;
            this.ape_materno_personal = ape_materno_personal;
            this.fecha_nacimiento_personal = fecha_nacimiento_personal;
            this.celular_personal = celular_personal;
            this.correo_personal = correo_personal;
            this.contrasena_personal = contrasena_personal;
            this.estado_personal = estado_personal;
            this.rol = rol;
        }

        public Personal()
        {
        }

        public int IdPersonal
        {
            get
            {
                return idPersonal;
            }

            set
            {
                idPersonal = value;
            }
        }

        public string Rut_personal
        {
            get
            {
                return rut_personal;
            }

            set
            {
                rut_personal = value;
            }
        }

        public string Nombres_personal
        {
            get
            {
                return nombres_personal;
            }

            set
            {
                nombres_personal = value;
            }
        }

        public string Ape_paterno_personal
        {
            get
            {
                return ape_paterno_personal;
            }

            set
            {
                ape_paterno_personal = value;
            }
        }

        public string Ape_materno_personal
        {
            get
            {
                return ape_materno_personal;
            }

            set
            {
                ape_materno_personal = value;
            }
        }

        public DateTime Fecha_nacimiento_personal
        {
            get
            {
                return fecha_nacimiento_personal;
            }

            set
            {
                fecha_nacimiento_personal = value;
            }
        }

        public string Celular_personal
        {
            get
            {
                return celular_personal;
            }

            set
            {
                celular_personal = value;
            }
        }

        public string Correo_personal
        {
            get
            {
                return correo_personal;
            }

            set
            {
                correo_personal = value;
            }
        }

        public string Contrasena_personal
        {
            get
            {
                return contrasena_personal;
            }

            set
            {
                contrasena_personal = value;
            }
        }

        public int Estado_personal
        {
            get
            {
                return estado_personal;
            }

            set
            {
                estado_personal = value;
            }
        }

        public Rol Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }

        public class EqualityComparer : IEqualityComparer<Personal>
        {

            public bool Equals(Personal x, Personal y)
            {
                return x.idPersonal == y.idPersonal;
            }

            public int GetHashCode(Personal obj)
            {
                return obj.idPersonal.GetHashCode();
            }
        }
    }
}
