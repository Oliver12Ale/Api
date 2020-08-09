using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Models.Models;

namespace WebApi.Models.Context
{
    public partial class SecContext : DbContext
    {
        public SecContext()
        {
        }

        public SecContext(DbContextOptions<SecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetallePrueba> DetallePrueba { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<NivelesUsuarios> NivelesUsuarios { get; set; }
        public virtual DbSet<Opciones> Opciones { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }
        public virtual DbSet<Pruebas> Pruebas { get; set; }
        public virtual DbSet<Tecnologias> Tecnologias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Evaluacion;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePrueba>(entity =>
            {
                entity.HasKey(e => e.IdDetallePrueba);

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Pregunta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPruebaNavigation)
                    .WithMany(p => p.DetallePrueba)
                    .HasForeignKey(d => d.IdPrueba)
                    .HasConstraintName("FK_DetallePrueba_Pruebas");
            });

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.HasKey(e => e.IdNivel);

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelesUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdNivelUsuario);

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.NivelesUsuarios)
                    .HasForeignKey(d => d.IdNivel)
                    .HasConstraintName("FK_NivelesUsuarios_Niveles");

                entity.HasOne(d => d.IdTecnologiaNavigation)
                    .WithMany(p => p.NivelesUsuarios)
                    .HasForeignKey(d => d.IdTecnologia)
                    .HasConstraintName("FK_NivelesUsuarios_Tecnologias");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.NivelesUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_NivelesUsuarios_Usuarios");
            });

            modelBuilder.Entity<Opciones>(entity =>
            {
                entity.HasKey(e => e.IdOpcion);

                entity.Property(e => e.Opcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.Opciones)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opciones_Preguntas");
            });

            modelBuilder.Entity<Preguntas>(entity =>
            {
                entity.HasKey(e => e.IdPregunta);

                entity.Property(e => e.NombrePregunta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTecnologiaNavigation)
                    .WithMany(p => p.Preguntas)
                    .HasForeignKey(d => d.IdTecnologia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preguntas_Tecnologias");
            });

            modelBuilder.Entity<Pruebas>(entity =>
            {
                entity.HasKey(e => e.IdPrueba)
                    .HasName("PK_Pruebas_1");

                entity.Property(e => e.FechaIni).HasColumnType("date");

                entity.Property(e => e.FechaTer).HasColumnType("date");

                entity.HasOne(d => d.IdTecnologiaNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.IdTecnologia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pruebas_Tecnologias");

                entity.HasOne(d => d.NivelNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.Nivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pruebas_Niveles");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pruebas_Usuarios");
            });

            modelBuilder.Entity<Tecnologias>(entity =>
            {
                entity.HasKey(e => e.IdTecnologia);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.NombreTec)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuarios_1");

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Usuarios_1")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario)
                    .HasName("IX_Usuarios")
                    .IsUnique();

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
