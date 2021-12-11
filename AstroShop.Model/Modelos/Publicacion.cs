using System;

namespace AstroShop.Model
{
    public class Publicacion
    {
        public string URL { get; set; }
        public virtual Concepto Concepto { get; set; }
        public virtual int ConceptoID { get; set; }
        public int PublicacionID { get; set; }
        public bool Habilitada { get; set; }
    }
}
