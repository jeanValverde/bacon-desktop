using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Cliente
    {
        private int idCliente;
        private string nombre;
        private DateTime fechaIngreso;
        private DateTime fechaSalida;
        private EstadoCliente estadoCliente;
        private Mesa mesa;


        public Cliente()
        {

        }

        public Cliente(int idCliente, string nombre, DateTime fechaIngreso, DateTime fechaSalida, EstadoCliente estadoCliente, Mesa mesa)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            this.estadoCliente = estadoCliente;
            this.mesa = mesa;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public EstadoCliente EstadoCliente { get => estadoCliente; set => estadoCliente = value; }
        public Mesa Mesa { get => mesa; set => mesa = value; }
    }
}
