using System;

namespace AstroShop.Model
{
    public class Concepto
    {
        public string NombreConcepto { get; set; }
        public string DescripcionConcepto { get; set; }
        public float Precio { get; set; }
        public int stock { get; set; }
        public virtual Usuario Vendedor { get; set; }
        public virtual int VendedorID { get; set; }
        public byte[] Imagen { get; set; }
        public int ConceptoID { get; set; }
        public Concepto(string NombreConcepto, string DescripcionConcepto, int stock, float precio, byte[] imagen)
        {
            this.NombreConcepto = NombreConcepto;
            this.DescripcionConcepto = DescripcionConcepto;
            this.Precio = precio;
            this.stock = stock;
            this.Imagen = imagen;
        }

    }
}
