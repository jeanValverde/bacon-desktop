using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class Boleta
    {
        private int idBoleta;
        private int totalMesa;
        private int montoPagado;
        private int vuelto;
        private DateTime fecha;
        private int numeroTargeta;
        private int mesVencimiento;
        private int anioVencimiento;
        private int cvvSeuridad;
        private int montoExtra;
        private string motivoMontoExtra;
        private int operacion;
        private Cliente cliente;
        private MedioPago medioPago;

        public Boleta()
        {

        }

        public Boleta(int idBoleta, int totalMesa, int montoPagado, int vuelto, DateTime fecha, int numeroTargeta, int mesVencimiento, int anioVencimiento, int cvvSeuridad, int montoExtra, string motivoMontoExtra, int operacion, Cliente cliente, MedioPago medioPago)
        {
            this.idBoleta = idBoleta;
            this.totalMesa = totalMesa;
            this.montoPagado = montoPagado;
            this.vuelto = vuelto;
            this.fecha = fecha;
            this.numeroTargeta = numeroTargeta;
            this.mesVencimiento = mesVencimiento;
            this.anioVencimiento = anioVencimiento;
            this.cvvSeuridad = cvvSeuridad;
            this.montoExtra = montoExtra;
            this.motivoMontoExtra = motivoMontoExtra;
            this.operacion = operacion;
            this.cliente = cliente;
            this.medioPago = medioPago;
        }

        public int IdBoleta { get => idBoleta; set => idBoleta = value; }
        public int TotalMesa { get => totalMesa; set => totalMesa = value; }
        public int MontoPagado { get => montoPagado; set => montoPagado = value; }
        public int Vuelto { get => vuelto; set => vuelto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int NumeroTargeta { get => numeroTargeta; set => numeroTargeta = value; }
        public int MesVencimiento { get => mesVencimiento; set => mesVencimiento = value; }
        public int AnioVencimiento { get => anioVencimiento; set => anioVencimiento = value; }
        public int CvvSeuridad { get => cvvSeuridad; set => cvvSeuridad = value; }
        public int MontoExtra { get => montoExtra; set => montoExtra = value; }
        public string MotivoMontoExtra { get => motivoMontoExtra; set => motivoMontoExtra = value; }
        public int Operacion { get => operacion; set => operacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public MedioPago MedioPago { get => medioPago; set => medioPago = value; }

        public class EqualityComparer : IEqualityComparer<Boleta>
        {

            public bool Equals(Boleta x, Boleta y)
            {
                return x.idBoleta == y.idBoleta;
            }

            public int GetHashCode(Boleta obj)
            {
                return obj.idBoleta.GetHashCode();
            }
        }
    }
}
