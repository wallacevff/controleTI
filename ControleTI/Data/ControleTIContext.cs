﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleTI.Models;

namespace ControleTI.Data
{
    public class ControleTIContext : DbContext
    {
        public ControleTIContext (DbContextOptions<ControleTIContext> options)
            : base(options)
        {
        }

        public DbSet<ControleTI.Models.Filial> Filial { get; set; }
        public DbSet<ControleTI.Models.Setor> Setor { get; set; }
        public DbSet<ControleTI.Models.Usuario> Usuario { get; set; }
        public DbSet<ControleTI.Models.Software> Software { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControleTI.Models.SerialKey>()
                .HasKey(c => new { c.SoftwareId, c.Key });
        }

        public DbSet<ControleTI.Models.SerialKey> SerialKey { get; set; }
        public DbSet<ControleTI.Models.TipoDispositivo> TipoDispositivo { get; set; }
        public DbSet<ControleTI.Models.Dispositivo> Dispositivo { get; set; }
    }
}
