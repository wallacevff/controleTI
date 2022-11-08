using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ControleTI.Models;

namespace ControleTI.Data
{
    public class ControleTIContext : IdentityDbContext<IdentityUser>
    {
        public ControleTIContext(DbContextOptions<ControleTIContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ControleTI.Models.SerialKey>().HasKey(c => new { c.SoftwareId, c.Key });
            

            modelBuilder.Entity<DispositivoSoftware>()
                .HasOne(d => d.Software)
                .WithMany(ds => ds.DispositivosSoftwares)
                .HasForeignKey(si => si.SoftwareId);

            modelBuilder.Entity<DispositivoSoftware>()
                .HasOne(d => d.Dispositivo)
                .WithMany(ds => ds.DispositivosSoftwares)
                .HasForeignKey(di => di.DispositivoId);

            modelBuilder.Entity<DispositivoSoftware>()
                .HasOne(d => d.SerialKey)
                .WithMany(sks => sks.DispositivosSoftwares)
                .HasForeignKey(sk => sk.SerialKeyId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ControleTI.Models.Filial> Filial { get; set; }
        public DbSet<ControleTI.Models.Setor> Setor { get; set; }
        public DbSet<ControleTI.Models.Usuario> Usuario { get; set; }
        public DbSet<ControleTI.Models.Software> Software { get; set; }
        public DbSet<ControleTI.Models.SerialKey> SerialKey { get; set; }
        public DbSet<ControleTI.Models.TipoDispositivo> TipoDispositivo { get; set; }
        public DbSet<ControleTI.Models.Dispositivo> Dispositivo { get; set; }
        public DbSet<ControleTI.Models.DispositivoSoftware> DispositivoSoftware { get; set; }
        public DbSet<ControleTI.Models.Status> Status { get; set; }
        //public DbSet<ControleTI.Models.PontoRede> PontoRede { get; set; }
        public DbSet<ControleTI.Models.EmpresaParceira> EmpresaParceira { get; set; }
        public DbSet<ControleTI.Models.Contrato> Contrato { get; set; }
        //public DbSet<ControleTI.Models.UsuarioLic> UsuarioLic { get; set; }
    }
}
