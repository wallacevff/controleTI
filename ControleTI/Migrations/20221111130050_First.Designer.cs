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
    [Migration("20221111130050_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleTI.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("EmpresaParceiraId");

                    b.Property<DateTime>("Fim");

                    b.Property<DateTime>("Inicio");

                    b.Property<int>("UsuarioId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaParceiraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("contrato");
                });

            modelBuilder.Entity("ControleTI.Models.Dispositivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hd");

                    b.Property<string>("MacAdress");

                    b.Property<string>("Memoria");

                    b.Property<string>("Nome");

                    b.Property<string>("Processador");

                    b.Property<int>("StatusId");

                    b.Property<int>("TipoDispositivoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipoDispositivoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("dispositivo");
                });

            modelBuilder.Entity("ControleTI.Models.DispositivoSoftware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DispositivoId");

                    b.Property<string>("IdInstalacao");

                    b.Property<int?>("SerialKeyId");

                    b.Property<int>("SoftwareId");

                    b.HasKey("Id");

                    b.HasIndex("DispositivoId");

                    b.HasIndex("SerialKeyId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("dispositivosoftware");
                });

            modelBuilder.Entity("ControleTI.Models.EmpresaParceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.HasKey("Id");

                    b.ToTable("empresaparceira");
                });

            modelBuilder.Entity("ControleTI.Models.Filial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("filial");
                });

            modelBuilder.Entity("ControleTI.Models.SerialKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("Quantidade");

                    b.Property<int>("Restantes");

                    b.Property<int>("SoftwareId");

                    b.Property<int>("Utilizadas");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareId");

                    b.ToTable("serialkey");
                });

            modelBuilder.Entity("ControleTI.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("setor");
                });

            modelBuilder.Entity("ControleTI.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("software");
                });

            modelBuilder.Entity("ControleTI.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusNome");

                    b.HasKey("StatusId");

                    b.ToTable("status");
                });

            modelBuilder.Entity("ControleTI.Models.TipoDispositivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("tipodispositivo");
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

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ControleTI.Models.Contrato", b =>
                {
                    b.HasOne("ControleTI.Models.EmpresaParceira", "EmpresaParceira")
                        .WithMany("Contratos")
                        .HasForeignKey("EmpresaParceiraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleTI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleTI.Models.Dispositivo", b =>
                {
                    b.HasOne("ControleTI.Models.Status", "Status")
                        .WithMany("Dispositivos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}