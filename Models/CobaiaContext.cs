using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class CobaiaContext : DbContext
    {
        public CobaiaContext()
        {
        }

        public CobaiaContext(DbContextOptions<CobaiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Galeria> Galeria { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        /*
       atualizar database pelo console
       Scaffold-DbContext -Connection "Server=SKYDAWN;Database=cobaia;Integrated Security=True;Trusted_Connection=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -context CobaiaContext -Project WebApi -force
        */




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Galeria>(entity =>
            {
                entity.ToTable("GALERIA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caminho).IsUnicode(false);

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.FotoDescricao).IsUnicode(false);

                entity.Property(e => e.FotoNome).IsUnicode(false);

                entity.Property(e => e.Geolocalizacao).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Galeria)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GALERIA_USUARIO");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.NumCode);

                entity.ToTable("PAIS");

                entity.Property(e => e.NumCode).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Iso)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Iso3)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasColumnName("NameEN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEs)
                    .IsRequired()
                    .HasColumnName("NameES")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamePt)
                    .IsRequired()
                    .HasColumnName("NamePT")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geolocalizacao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);
            });
        }
    }
}
