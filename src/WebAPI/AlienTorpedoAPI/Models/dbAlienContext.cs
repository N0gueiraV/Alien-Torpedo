using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlienTorpedoAPI.Models
{
    public partial class dbAlienContext : DbContext
    {
        //Vinicius - Construtur para setar a connectionString no dbcontext - INI 
        public dbAlienContext(DbContextOptions<dbAlienContext> options) : base(options)
        { }
        //Vinicius - Construtur para setar a connectionString no dbcontext - FIM

        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<GrupoEvento> GrupoEvento { get; set; }
        public virtual DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.CdEvento)
                    .HasName("pk_cd_evento");

                entity.Property(e => e.CdEvento)
                    .HasColumnName("Cd_evento")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdTipoEvento).HasColumnName("Cd_tipo_evento");

                entity.Property(e => e.CdUsuario).HasColumnName("Cd_usuario");

                entity.Property(e => e.DvParticular).HasColumnName("Dv_particular");

                entity.Property(e => e.NmEndereco)
                    .HasColumnName("Nm_endereco")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NmEvento)
                    .HasColumnName("Nm_evento")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.VlEvento).HasColumnName("Vl_evento");

                entity.Property(e => e.VlNota).HasColumnName("Vl_nota");

                entity.HasOne(d => d.CdTipoEventoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.CdTipoEvento)
                    .HasConstraintName("fk_evento_tipo_evento");

                entity.HasOne(d => d.CdUsuarioNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.CdUsuario)
                    .HasConstraintName("fk_evento_usuario");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.CdGrupo)
                    .HasName("pk_cd_grupo");

                entity.Property(e => e.CdGrupo)
                    .HasColumnName("Cd_grupo")
                    .ValueGeneratedNever();

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("Dt_inclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmGrupo)
                    .HasColumnName("Nm_grupo")
                    .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<GrupoEvento>(entity =>
            {
                entity.HasKey(e => e.IdGrupoEvento)
                    .HasName("pk_id_grupo_evento");

                entity.ToTable("Grupo_evento");

                entity.Property(e => e.IdGrupoEvento)
                    .HasColumnName("Id_grupo_evento")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdEvento).HasColumnName("Cd_evento");

                entity.Property(e => e.CdGrupo).HasColumnName("Cd_grupo");

                entity.Property(e => e.DtEvento)
                    .HasColumnName("Dt_evento")
                    .HasColumnType("datetime");

                entity.Property(e => e.NmDescricao)
                    .HasColumnName("Nm_descricao")
                    .HasColumnType("varchar(80)");

                entity.HasOne(d => d.CdEventoNavigation)
                    .WithMany(p => p.GrupoEvento)
                    .HasForeignKey(d => d.CdEvento)
                    .HasConstraintName("fk_grupo_evento_evento");

                entity.HasOne(d => d.CdGrupoNavigation)
                    .WithMany(p => p.GrupoEvento)
                    .HasForeignKey(d => d.CdGrupo)
                    .HasConstraintName("fk_grupo_evento_grupo");
            });

            modelBuilder.Entity<GrupoUsuario>(entity =>
            {
                entity.HasKey(e => new { e.CdUsuario, e.CdGrupo })
                    .HasName("pk_cd_usuario_grupo");

                entity.ToTable("Grupo_usuario");

                entity.Property(e => e.CdUsuario).HasColumnName("Cd_usuario");

                entity.Property(e => e.CdGrupo).HasColumnName("Cd_grupo");

                entity.Property(e => e.NrVoto).HasColumnName("Nr_voto");

                entity.HasOne(d => d.CdGrupoNavigation)
                    .WithMany(p => p.GrupoUsuario)
                    .HasForeignKey(d => d.CdGrupo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cd_grupo");

                entity.HasOne(d => d.CdUsuarioNavigation)
                    .WithMany(p => p.GrupoUsuario)
                    .HasForeignKey(d => d.CdUsuario)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cd_usuario");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.CdTipoEvento)
                    .HasName("pk_cd_tipo_evento");

                entity.ToTable("Tipo_evento");

                entity.Property(e => e.CdTipoEvento)
                    .HasColumnName("Cd_tipo_evento")
                    .ValueGeneratedNever();

                entity.Property(e => e.NmTipoEvento)
                    .HasColumnName("Nm_tipo_evento")
                    .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CdUsuario)
                    .HasName("pk_cd_usuario");

                entity.Property(e => e.CdUsuario).HasColumnName("Cd_usuario");

                entity.Property(e => e.DtInclusao)
                    .HasColumnName("Dt_inclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DvAtivo).HasColumnName("Dv_ativo");

                entity.Property(e => e.NmEmail)
                    .HasColumnName("Nm_email")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.NmSenha)
                    .HasColumnName("Nm_senha")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.NmUsuario)
                    .HasColumnName("Nm_usuario")
                    .HasColumnType("varchar(80)");
            });
        }
    }
}