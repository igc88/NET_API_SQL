using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Almacenes.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cajero> Cajeros { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Producto>(entity => {
                entity.ToTable("Productos");
                entity.HasKey(e => e.Codigo);
            });

            modelBuilder.Entity<Cajero>(entity => {
                entity.ToTable("Cajeros");
                entity.HasKey(e => e.Codigo);
            });

            modelBuilder.Entity<Maquina>(entity => {
                entity.ToTable("Maquinas_registradoras");
                entity.HasKey(e => e.Codigo);
            });

            modelBuilder.Entity<Venta>(entity => {
                entity.ToTable("Ventas");

                entity.HasKey(e => new { e.IdProducto, e.IdCajero, e.IdMaquina });

                entity.Property(e => e.IdCajero).HasColumnName("Cajero");
                entity.Property(e => e.IdMaquina).HasColumnName("Maquina");
                entity.Property(e => e.IdProducto).HasColumnName("Producto");

                entity.HasOne(d => d.Cajero).WithMany(p => p.Ventas).HasForeignKey(d => d.IdCajero).HasForeignKey("FK1");
                entity.HasOne(d => d.Maquina).WithMany(p => p.Ventas).HasForeignKey(d => d.IdMaquina).HasForeignKey("FK2");
                entity.HasOne(d => d.Producto).WithMany(p => p.Ventas).HasForeignKey(d => d.IdProducto).HasForeignKey("FK3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
    }
}
