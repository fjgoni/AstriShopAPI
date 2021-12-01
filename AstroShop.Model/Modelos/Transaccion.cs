using System;

namespace AstroShop.Model
{
    public class Transaccion
    {
        public Usuario Comprador { get; set; }
        public Concepto Concepto { get; set; }
        public int TipoTransaccion { get; set; }
        public float Monto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TransaccionID { get; set; }
        public int Cantidad { get; set; }
        public Transaccion(Concepto Concepto, int TipoTransaccion, float Monto, Usuario Comprador, DateTime FechaCreacion, int Cantidad)
        {
            this.Comprador = Comprador;
            this.Concepto = Concepto;
            this.TipoTransaccion = TipoTransaccion;
            this.Monto = Monto;
            this.FechaCreacion = FechaCreacion;
            this.Cantidad = Cantidad;
        }

    }
}
