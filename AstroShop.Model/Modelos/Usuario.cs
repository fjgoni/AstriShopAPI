using System;

namespace AstroShop.Model
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int UsuarioID { get; set; }
        public bool Rol { get; }

        public Usuario(string nombre, string apellido, string mail, string dni, DateTime fechaNacimiento)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.DNI = dni;
            this.FechaNacimiento = fechaNacimiento;
        }

    }
}
