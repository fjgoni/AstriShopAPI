using System;

namespace AstroShop.Model
{
    public class Publicacion
    {
        public string URL { get; set; }
        public Concepto Concepto { get; set; }
        public int PublicacionID { get; set; }
        public bool Habilitada { get; set; }
        public Publicacion(string URL, Concepto Concepto, bool Habilitada)
        {
            this.URL = URL;
            this.Concepto = Concepto;
            this.Habilitada = Habilitada;
        }
    }
}
