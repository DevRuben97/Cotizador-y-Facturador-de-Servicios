﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Cotizador.Models
{
    public class CotizadorContext :DbContext
    {
       public DbSet<Servicios> servicio { get; set; }
       public DbSet<Clientes> cliente { get; set; }
       public DbSet<Cotizaciones> cotizacion { get; set; }
       public DbSet<DetalleCotizacion> detalleCoti { get; set; }
       public DbSet<Usuarios> Usuario { get; set; }

        public CotizadorContext() : base("ConectInfo")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuraciones Adicionales A La Tabla.
            modelBuilder.Entity<Cotizaciones>().Property(x => x.Total).HasPrecision(5, 3);
            modelBuilder.Entity<Servicios>().Property(x => x.Costo).HasPrecision(5, 3);


            //Configuracion De la Tabla Usuario
            modelBuilder.Entity<Usuarios>().HasKey(x => x.id);
            modelBuilder.Entity<Usuarios>().Property(x => x.Nombre).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Apellido).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Telefono).HasColumnType("varchar").HasMaxLength(13).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Direccion).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Usuario).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Clave).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}