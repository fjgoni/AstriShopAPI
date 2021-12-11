using System;

namespace AstroShop.Model
{
    public class Transaccion
    {
        public virtual Usuario Comprador { get; set; }
        public int CompradorID { get; set; }
        public virtual Concepto Concepto { get; set; }
        public int ConceptoID { get; set; }
        public int TipoTransaccion { get; set; }
        public float Monto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TransaccionID { get; set; }
        public int Cantidad { get; set; }
   

    }
}
