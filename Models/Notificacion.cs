using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Notificacion
    {
        private int idNotificacion;
        private string descripcion;
        private int estado;
        private Rol rol;
        private DateTime fecha;
        private string asunto;

        public Notificacion()
        {

        }

        public Notificacion(int idNotificacion, string descripcion, int estado, Rol rol, DateTime fecha, string asunto)
        {
            this.idNotificacion = idNotificacion;
            this.descripcion = descripcion;
            this.estado = estado;
            this.rol = rol;
            this.fecha = fecha;
            this.asunto = asunto;
        }

        public int IdNotificacion { get => idNotificacion; set => idNotificacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Estado { get => estado; set => estado = value; }
        public Rol Rol { get => rol; set => rol = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Asunto { get => asunto; set => asunto = value; }


        public class EqualityComparer : IEqualityComparer<Notificacion>
        {

            public bool Equals(Notificacion x, Notificacion y)
            {
                return x.idNotificacion == y.idNotificacion;
            }

            public int GetHashCode(Notificacion obj)
            {
                return obj.idNotificacion.GetHashCode();
            }
        }

    }
}
