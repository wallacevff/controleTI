﻿// <auto-generated />
using System;
using ControleTI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleTI.Migrations
{
    [DbContext(typeof(ControleTIContext))]
    [Migration("20210620184405_SerialKeyIdNullable")]
    partial class SerialKeyIdNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleTI.Models.Dispositivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MacAdress");

                    b.Property<string>("Nome");

                    b.Property<int>("TipoDispositivoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("TipoDispositivoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Dispositivo");
                });

            modelBuilder.Entity("ControleTI.Models.DispositivoSoftware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DispositivoId");

                    b.Property<int?>("SerialKeyId");

                    b.Property<int>("SoftwareId");

                    b.HasKey("Id");

                    b.HasIndex("DispositivoId");

                    b.HasIndex("SerialKeyId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("DispositivoSoftware");
                });

            modelBuilder.Entity("ControleTI.Models.Filial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("ControleTI.Models.SerialKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdInstalacao");

                    b.Property<string>("Key");

                    b.Property<int>("Quantidade");

                    b.Property<int>("Restantes");

                    b.Property<int>("SoftwareId");

                    b.Property<int>("Utilizadas");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareId");

                    b.ToTable("SerialKey");
                });

            modelBuilder.Entity("ControleTI.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("ControleTI.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("ControleTI.Models.TipoDispositivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("TipoDispositivo");
                });

            modelBuilder.Entity("ControleTI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FilialId");

                    b.Property<string>("NomeCompleto");

                    b.Property<string>("NomeUsu");

                    b.Property<int>("SetorId");

                    b.HasKey("Id");

                    b.HasIndex("FilialId");

                    b.HasIndex("SetorId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ControleTI.Models.Dispositivo", b =>
                {
                    b.HasOne("ControleTI.Models.TipoDispositivo", "TipoDispositivo")
                        .WithMany("Dispositivos")
                        .HasForeignKey("TipoDispositivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleTI.Models.Usuario", "Usuario")
                        .WithMany("Dispositivo")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleTI.Models.DispositivoSoftware", b =>
                {
                    b.HasOne("ControleTI.Models.Dispositivo", "Dispositivo")
                        .WithMany("DispositivosSoftwares")
                        .HasForeignKey("DispositivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleTI.Models.SerialKey", "SerialKey")
                        .WithMany("DispositivosSoftwares")
                        .HasForeignKey("SerialKeyId");

                    b.HasOne("ControleTI.Models.Software", "Software")
                        .WithMany("DispositivosSoftwares")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleTI.Models.SerialKey", b =>
                {
                    b.HasOne("ControleTI.Models.Software", "Software")
                        .WithMany("Keys")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleTI.Models.Usuario", b =>
                {
                    b.HasOne("ControleTI.Models.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleTI.Models.Setor", "Setor")
                        .WithMany("Usuarios")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
