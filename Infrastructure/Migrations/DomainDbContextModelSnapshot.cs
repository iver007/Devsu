﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DomainDbContext))]
    partial class DomainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Cuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<double>("SaldoActual")
                        .HasColumnType("float");

                    b.Property<double>("SaldoInicial")
                        .HasColumnType("float");

                    b.Property<int>("TipoCuenta")
                        .HasColumnType("int");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("ClientesId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Domain.Entity.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<int>("TipoMovimiento")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("Domain.Entity.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entity.Cliente", b =>
                {
                    b.HasBaseType("Domain.Entity.Persona");

                    b.Property<Guid>("Codigo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Entity.Cuenta", b =>
                {
                    b.HasOne("Domain.Entity.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("Domain.Entity.Movimiento", b =>
                {
                    b.HasOne("Domain.Entity.Cuenta", "Cuentas")
                        .WithMany()
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("Domain.Entity.Cliente", b =>
                {
                    b.HasOne("Domain.Entity.Persona", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entity.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
