using AstroShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstroShopDAL.Context
{
    public class dbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }

        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  
            // Map entities to tables  
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Publicacion>().ToTable("publicacion");
            modelBuilder.Entity<Transaccion>().ToTable("transaccion");
            modelBuilder.Entity<Concepto>().ToTable("concepto");

            // Configure Primary Keys  
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioID).HasName("UsuarioID");
            modelBuilder.Entity<Publicacion>().HasKey(p => p.PublicacionID).HasName("PublicacionID");
            modelBuilder.Entity<Transaccion>().HasKey(t => t.TransaccionID).HasName("TransaccionID");
            modelBuilder.Entity<Concepto>().HasKey(c => c.ConceptoID).HasName("ConceptoID");

            //CONFIG USUARIO
            modelBuilder.Entity<Usuario>().Property(ug => ug.UsuarioID).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Usuario>().Property(ug => ug.Nombre).HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(ug => ug.Apellido).HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(ug => ug.Mail).HasColumnType("varchar(50)").IsRequired(); 
            modelBuilder.Entity<Usuario>().Property(ug => ug.DNI).HasColumnType("varchar(8)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(ug => ug.FechaNacimiento).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Usuario>().Property(ug => ug.Rol).HasColumnType("tinyint").IsRequired(false);

            //CONFIG PUBLICACION
            modelBuilder.Entity<Publicacion>().Property(u => u.PublicacionID).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Publicacion>().Property(u => u.URL).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Publicacion>().HasOne(x => x.Concepto).WithOne()
               .HasForeignKey<Concepto>(x => x.ConceptoID)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Publicacion>().Property(u => u.ConceptoID).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Publicacion>().Property(u => u.Habilitada).HasColumnType("tinyint").IsRequired();

            //CONFIG CONCEPTO
            modelBuilder.Entity<Concepto>().Property(u => u.ConceptoID).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Concepto>().Property(u => u.NombreConcepto).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Concepto>().Property(u => u.DescripcionConcepto).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Concepto>().Property(u => u.Precio).HasColumnType("float").IsRequired();
            modelBuilder.Entity<Concepto>().Property(u => u.stock).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Concepto>().HasOne(x => x.Vendedor).WithOne()
                .HasForeignKey<Usuario>(x => x.UsuarioID)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Concepto>().Property(u => u.Imagen).HasColumnType("blob").IsRequired();
            modelBuilder.Entity<Concepto>().Property(u => u.VendedorID).HasColumnType("int").IsRequired();

            //CONFIG TRANSACCION
            modelBuilder.Entity<Transaccion>().Property(ug => ug.TransaccionID).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Transaccion>().Property(ug => ug.TipoTransaccionID).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Transaccion>().Property(ug => ug.Monto).HasColumnType("float").IsRequired();
            modelBuilder.Entity<Transaccion>().Property(ug => ug.FechaCreacion).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Transaccion>().HasOne(x => x.Concepto).WithOne()
               .HasForeignKey<Concepto>(x => x.ConceptoID)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaccion>().HasOne(x => x.Comprador).WithOne()
            .HasForeignKey<Usuario>(x => x.UsuarioID)
            .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Transaccion>().Property(u => u.ConceptoID).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Transaccion>().Property(u => u.Cantidad).HasColumnType("int").IsRequired();


        }

    }
}
