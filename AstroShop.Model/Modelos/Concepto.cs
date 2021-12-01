using System;

namespace AstroShop.Model
{
    public class Concepto
    {
        public string NombreConcepto { get; set; }
        public string DescripcionConcepto { get; set; }
        public float Precio { get; set; }
        public int stock { get; set; }
        public Usuario Vendedor { get; set; }
        public byte[] Imagen { get; }

        public Concepto(string NombreConcepto, string DescripcionConcepto, int stock, float precio, Usuario Vendedor, byte[] imagen)
        {
            this.NombreConcepto = NombreConcepto;
            this.DescripcionConcepto = DescripcionConcepto;
            this.Precio = precio;
            this.stock = stock;
            this.Vendedor = Vendedor;
            this.Imagen = imagen;
        }

    }
}
