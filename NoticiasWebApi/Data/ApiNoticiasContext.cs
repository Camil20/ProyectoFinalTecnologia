using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NoticiasWebApi.Models;

#nullable disable

namespace NoticiasWebApi.Data
{
    public partial class ApiNoticiasContext : DbContext
    {
        public ApiNoticiasContext()
        {
        }

        public ApiNoticiasContext(DbContextOptions<ApiNoticiasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Fuente> Fuentes { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-13989EO;Initial Catalog=ApiNoticias; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Contenido).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);

                entity.Property(e => e.UrlToImage).IsUnicode(false);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("fk_IdAutorr");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("fk_IdCategoria");

                entity.HasOne(d => d.Fuente)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.FuenteId)
                    .HasConstraintName("fk_IdFuente");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("fk_IdPais");
            });

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.AutorId)
                    .HasName("pk_IdAutor");

                entity.Property(e => e.NombreAutor).IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Autores)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("fk_IdUsuario");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.NombreCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Fuente>(entity =>
            {
                entity.Property(e => e.NombreFuente).IsUnicode(false);
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.PaisId)
                    .HasName("pk_PaisId");

                entity.Property(e => e.NombrePais).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Contrasena).IsUnicode(false);

                entity.Property(e => e.NombreCompleto).IsUnicode(false);

                entity.Property(e => e.NombreUsuario).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
