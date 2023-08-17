using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    //public class AplicationDbContext : DbContext
    public class AplicationDbContext : IdentityDbContext
    {
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<EnvioMaritimo> EnviosMaritimos { get; set; }
        public DbSet<EnvioTerrestre> EnviosTerrestres { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Puerto> Puertos { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Cliente - Envio
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Envios)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .IsRequired();

            // Relación Producto - Envio
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Envios)
                .WithOne(e => e.Producto)
                .HasForeignKey(e => e.IdProducto)
                .IsRequired();
            
            // Relación Envio - EnvioMaritimo
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EnvioMaritimo)
                .WithOne(em => em.Envio)
                .HasForeignKey<EnvioMaritimo>(em => em.IdEnvio);

            // Relación Envio - EnvioTerrestre
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EnvioTerrestre)
                .WithOne(et => et.Envio)
                .HasForeignKey<EnvioTerrestre>(et => et.IdEnvio);

            // Relación EnvioMaritimo - Puerto
            modelBuilder.Entity<EnvioMaritimo>()
                .HasOne(em => em.Puerto)
                .WithMany(p => p.EnviosMaritimos)
                .HasForeignKey(em => em.IdPuerto);

            // Relación EnvioTerrestre - Bodega
            modelBuilder.Entity<EnvioTerrestre>()
                .HasOne(et => et.Bodega)
                .WithMany(b => b.EnviosTerrestres)
                .HasForeignKey(et => et.IdBodega);

        }
    }
}
