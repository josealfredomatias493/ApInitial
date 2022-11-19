﻿// <auto-generated />
using System;
using ApInitial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApInitial.Migrations
{
    [DbContext(typeof(CITASMEDICASContext))]
    [Migration("20221119203732_db")]
    partial class db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApInitial.Models.Citas", b =>
                {
                    b.Property<int>("CtCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CtCodigo"), 1L, 1);

                    b.Property<string>("CtDescripcion")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CtEstatus")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<int>("DocCodigo")
                        .HasColumnType("int");

                    b.Property<int>("PacCodigo")
                        .HasColumnType("int");

                    b.HasKey("CtCodigo");

                    b.HasIndex("DocCodigo");

                    b.HasIndex("PacCodigo");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("ApInitial.Models.Doctores", b =>
                {
                    b.Property<int>("DocCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocCodigo"), 1L, 1);

                    b.Property<string>("DocApellido")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DocEmail")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DocEspecialidades")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DocEstatus")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("DocNombre")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DocTelefono")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("UserCodigo")
                        .HasColumnType("int");

                    b.HasKey("DocCodigo");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("ApInitial.Models.Horario", b =>
                {
                    b.Property<int>("HrCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HrCodigo"), 1L, 1);

                    b.Property<string>("HrEstatus")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("HrFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HrIncio")
                        .HasColumnType("datetime2");

                    b.HasKey("HrCodigo");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("ApInitial.Models.Pacientes", b =>
                {
                    b.Property<int>("PacCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacCodigo"), 1L, 1);

                    b.Property<string>("PacApellido")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PacDireccion")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PacEmail")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PacEstatus")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("PacFechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("PacNombre")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PacTelefono")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("UserCodigo")
                        .HasColumnType("int");

                    b.HasKey("PacCodigo");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ApInitial.Models.Roles", b =>
                {
                    b.Property<int>("RlCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RlCodigo"), 1L, 1);

                    b.Property<string>("RlEstatus")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("RlNombre")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("RlCodigo");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ApInitial.Models.Usuarios", b =>
                {
                    b.Property<int>("UserCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCodigo"), 1L, 1);

                    b.Property<int>("RlCodigo")
                        .HasColumnType("int");

                    b.Property<string>("UserContraseña")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UserEstatus")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("UserNombre")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("UserCodigo");

                    b.HasIndex("RlCodigo");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DoctoresHorario", b =>
                {
                    b.Property<int>("DoctoresDocCodigo")
                        .HasColumnType("int");

                    b.Property<int>("HorariosHrCodigo")
                        .HasColumnType("int");

                    b.HasKey("DoctoresDocCodigo", "HorariosHrCodigo");

                    b.HasIndex("HorariosHrCodigo");

                    b.ToTable("DoctoresHorario");
                });

            modelBuilder.Entity("ApInitial.Models.Citas", b =>
                {
                    b.HasOne("ApInitial.Models.Doctores", "Doctores")
                        .WithMany("Citas")
                        .HasForeignKey("DocCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApInitial.Models.Pacientes", "Pacientes")
                        .WithMany("citas")
                        .HasForeignKey("PacCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctores");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApInitial.Models.Usuarios", b =>
                {
                    b.HasOne("ApInitial.Models.Roles", "Roles")
                        .WithMany("Usuarios")
                        .HasForeignKey("RlCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("DoctoresHorario", b =>
                {
                    b.HasOne("ApInitial.Models.Doctores", null)
                        .WithMany()
                        .HasForeignKey("DoctoresDocCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApInitial.Models.Horario", null)
                        .WithMany()
                        .HasForeignKey("HorariosHrCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApInitial.Models.Doctores", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("ApInitial.Models.Pacientes", b =>
                {
                    b.Navigation("citas");
                });

            modelBuilder.Entity("ApInitial.Models.Roles", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
