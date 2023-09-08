﻿// <auto-generated />
using System;
using ApiTechOil.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTechOil.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230908070327_TechOil")]
    partial class TechOil
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiTechOil.Entities.Proyectos", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodProyecto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)")
                        .HasColumnName("Direccion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)")
                        .HasColumnName("Nombre");

                    b.HasKey("CodProyecto");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            CodProyecto = 1,
                            Direccion = "Sanchez 33, Glew",
                            Estado = 2,
                            Nombre = "Proyecto 001"
                        },
                        new
                        {
                            CodProyecto = 2,
                            Direccion = "Santa fe 342, Lomas de Zamora",
                            Estado = 1,
                            Nombre = "Proyecto 002"
                        },
                        new
                        {
                            CodProyecto = 3,
                            Direccion = " Lavalle 1674, CABA",
                            Estado = 2,
                            Nombre = "Proyecto 003"
                        });
                });

            modelBuilder.Entity("ApiTechOil.Entities.Servicios", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodServicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"));

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)")
                        .HasColumnName("Descr");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("Estado");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal")
                        .HasColumnName("ValorHora");

                    b.HasKey("CodServicio");

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            CodServicio = 1,
                            Descr = "Proyecto 001",
                            Estado = true,
                            ValorHora = 0.25m
                        },
                        new
                        {
                            CodServicio = 2,
                            Descr = "Proyecto 002",
                            Estado = false,
                            ValorHora = 0.25m
                        },
                        new
                        {
                            CodServicio = 3,
                            Descr = "Proyecto 003",
                            Estado = true,
                            ValorHora = 0.25m
                        });
                });

            modelBuilder.Entity("ApiTechOil.Entities.Trabajos", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodTrabajo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"));

                    b.Property<int>("CantHoras")
                        .HasColumnType("int")
                        .HasColumnName("CantHoras");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal")
                        .HasColumnName("Costo");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date")
                        .HasColumnName("Fecha");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal")
                        .HasColumnName("ValorHora");

                    b.HasKey("CodTrabajo");

                    b.ToTable("Trabajos");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 1,
                            CantHoras = 28,
                            CodProyecto = 1,
                            CodServicio = 2,
                            Costo = 150m,
                            Fecha = new DateTime(2023, 9, 8, 4, 3, 27, 734, DateTimeKind.Local).AddTicks(3419),
                            ValorHora = 0.25m
                        },
                        new
                        {
                            CodTrabajo = 2,
                            CantHoras = 28,
                            CodProyecto = 2,
                            CodServicio = 3,
                            Costo = 180m,
                            Fecha = new DateTime(2023, 9, 8, 4, 3, 27, 734, DateTimeKind.Local).AddTicks(3431),
                            ValorHora = 0.25m
                        },
                        new
                        {
                            CodTrabajo = 3,
                            CantHoras = 28,
                            CodProyecto = 3,
                            CodServicio = 3,
                            Costo = 190m,
                            Fecha = new DateTime(2023, 9, 8, 4, 3, 27, 734, DateTimeKind.Local).AddTicks(3432),
                            ValorHora = 0.25m
                        });
                });

            modelBuilder.Entity("ApiTechOil.Entities.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)")
                        .HasColumnName("CLave");

                    b.Property<int>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("Dni");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)")
                        .HasColumnName("Nombre");

                    b.Property<int>("PerfilUsuario")
                        .HasColumnType("int")
                        .HasColumnName("PerfilUsuario");

                    b.HasKey("CodUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Clave = "1234",
                            Dni = 31467581,
                            Nombre = "Martin Cabrera",
                            PerfilUsuario = 1
                        },
                        new
                        {
                            CodUsuario = 2,
                            Clave = "5678",
                            Dni = 37053098,
                            Nombre = "Florencia Gonzalez",
                            PerfilUsuario = 2
                        },
                        new
                        {
                            CodUsuario = 3,
                            Clave = "5792",
                            Dni = 58706438,
                            Nombre = "Salome Cabrera",
                            PerfilUsuario = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
