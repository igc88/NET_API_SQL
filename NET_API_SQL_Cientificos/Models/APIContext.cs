using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_API_SQL_Cientificos.Models {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Cientifico> Cientificos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Cientifico>(entity => {
                entity.ToTable("Cientificos");

                entity.HasKey(e => e.DNI);

                entity.Property(e => e.DNI).HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Proyecto>(entity => {
                entity.ToTable("Proyectos");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id")
                    .HasColumnType("char")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Horas)
                    .HasColumnName("Horas")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<Asignacion>(entity => {
                entity.ToTable("Asignaciones");

                entity.HasKey(e => new { e.CientificoDNI, e.ProyectoId });

                entity.HasOne(d => d.Cientifico).WithMany(p => p.Asignaciones).HasForeignKey(d => d.CientificoDNI).HasForeignKey("FK1");
                entity.HasOne(d => d.Proyecto).WithMany(p => p.Asignaciones).HasForeignKey(d => d.ProyectoId).HasForeignKey("FK2");
                               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
    }
}
