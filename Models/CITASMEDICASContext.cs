using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApInitial.Models
{
    public partial class CITASMEDICASContext : DbContext
    {
        public CITASMEDICASContext()
        {
        }

        public CITASMEDICASContext(DbContextOptions<CITASMEDICASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Doctore> Doctores { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.CtCodigo)
                    .HasName("PK__CITAS__8DE909DE4D5FCCF5");

                entity.ToTable("CITAS");

                entity.Property(e => e.CtCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("Ct_Codigo");

                entity.Property(e => e.CtDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Ct_Descripcion");

                entity.Property(e => e.CtDoctorAsignado).HasColumnName("Ct_DoctorAsignado");

                entity.Property(e => e.CtEstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ct_Estatus");

                entity.Property(e => e.CtPaciente).HasColumnName("Ct_Paciente");

                entity.HasOne(d => d.CtDoctorAsignadoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.CtDoctorAsignado)
                    .HasConstraintName("FK__CITAS__Ct_Doctor__47DBAE45");

                entity.HasOne(d => d.CtPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.CtPaciente)
                    .HasConstraintName("FK__CITAS__Ct_Pacien__46E78A0C");
            });

            modelBuilder.Entity<Doctore>(entity =>
            {
                entity.HasKey(e => e.DocCodigo)
                    .HasName("PK__DOCTORES__55EB809B2BEC3F90");

                entity.ToTable("DOCTORES");

                entity.Property(e => e.DocCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("Doc_Codigo");

                entity.Property(e => e.DocApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Apellido");

                entity.Property(e => e.DocEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Email");

                entity.Property(e => e.DocEspecialidades)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Especialidades");

                entity.Property(e => e.DocEstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Estatus");

                entity.Property(e => e.DocNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Nombre");

                entity.Property(e => e.DocTelefono)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Doc_Telefono");

                entity.Property(e => e.DocUsuario).HasColumnName("Doc_Usuario");

                entity.HasOne(d => d.DocUsuarioNavigation)
                    .WithMany(p => p.Doctores)
                    .HasForeignKey(d => d.DocUsuario)
                    .HasConstraintName("FK__DOCTORES__Doc_Us__403A8C7D");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.HrCodigo)
                    .HasName("PK__HORARIO__E53C963643A639B4");

                entity.ToTable("HORARIO");

                entity.Property(e => e.HrCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("Hr_Codigo");

                entity.Property(e => e.HrEstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hr_Estatus");

                entity.Property(e => e.HrFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("Hr_Final");

                entity.Property(e => e.HrIncio)
                    .HasColumnType("datetime")
                    .HasColumnName("Hr_Incio");

                entity.HasMany(d => d.HdCodigoDoctors)
                    .WithMany(p => p.HdCodigoHorarios)
                    .UsingEntity<Dictionary<string, object>>(
                        "Horariodoctor",
                        l => l.HasOne<Doctore>().WithMany().HasForeignKey("HdCodigoDoctor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__HORARIODO__HD_Co__440B1D61"),
                        r => r.HasOne<Horario>().WithMany().HasForeignKey("HdCodigoHorario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__HORARIODO__HD_Co__4316F928"),
                        j =>
                        {
                            j.HasKey("HdCodigoHorario", "HdCodigoDoctor").HasName("PK__HORARIOD__949DFB4D0FA94149");

                            j.ToTable("HORARIODOCTOR");

                            j.IndexerProperty<int>("HdCodigoHorario").HasColumnName("HD_CodigoHorario");

                            j.IndexerProperty<int>("HdCodigoDoctor").HasColumnName("HD_CodigoDoctor");
                        });
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.PacCodigo)
                    .HasName("PK__PACIENTE__BF56FA1AF7CC020C");

                entity.ToTable("PACIENTE");

                entity.Property(e => e.PacCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("Pac_Codigo");

                entity.Property(e => e.PacApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pac_Apellido");

                entity.Property(e => e.PacDireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Pac_Direccion");

                entity.Property(e => e.PacEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pac_Email");

                entity.Property(e => e.PacEstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Pac_Estatus");

                entity.Property(e => e.PacFechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Pac_FechaNacimiento");

                entity.Property(e => e.PacNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pac_Nombre");

                entity.Property(e => e.PacTelefono)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Pac_Telefono");

                entity.Property(e => e.PacUsuario).HasColumnName("Pac_Usuario");

                entity.HasOne(d => d.PacUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.PacUsuario)
                    .HasConstraintName("FK__PACIENTE__Pac_Us__3B75D760");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RlCodigo)
                    .HasName("PK__ROLES__68091C6DF4328834");

                entity.ToTable("ROLES");

                entity.Property(e => e.RlCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("RL_Codigo");

                entity.Property(e => e.RlEstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RL_Estatus");

                entity.Property(e => e.RlNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RL_Nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserCodigo)
                    .HasName("PK__USUARIO__A006161EF1EC6F44");

                entity.ToTable("USUARIO");

                entity.Property(e => e.UserCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("User_Codigo");

                entity.Property(e => e.UserContraseña)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Contraseña");

                entity.Property(e => e.UserEstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("User_Estatus");

                entity.Property(e => e.UserNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Nombre");

                entity.Property(e => e.UserRol).HasColumnName("User_Rol");

                entity.HasOne(d => d.UserRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UserRol)
                    .HasConstraintName("FK__USUARIO__User_Ro__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
