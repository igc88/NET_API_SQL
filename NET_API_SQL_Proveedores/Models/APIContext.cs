using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Proveedores.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Pieza> Cientificos { get; set; }
        public DbSet<Proveedor> Proyectos { get; set; }
        public DbSet<Suministro> Asignaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pieza>(entity => {
                entity.ToTable("Piezas");

                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Proveedor>(entity => {
                entity.ToTable("Proveedores");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id")
                    .HasColumnType("char")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suministro>(entity => {
                entity.ToTable("Suministra");

                entity.HasKey(e => new { e.CodigoPieza, e.ProveedorId });

                entity.Property(e => e.ProveedorId).HasColumnName("IdProveedor");

                entity.HasOne(d => d.Pieza).WithMany(p => p.Suministros).HasForeignKey(d => d.CodigoPieza).HasForeignKey("FK1");
                entity.HasOne(d => d.Proveedor).WithMany(p => p.Suministros).HasForeignKey(d => d.ProveedorId).HasForeignKey("FK2");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
    }
}
