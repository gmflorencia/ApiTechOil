using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTechOil.Migrations
{
    /// <inheritdoc />
    public partial class TechOil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    CodProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Direccion = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.CodProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    CodServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descr = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(38,17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.CodServicio);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    CodTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    CodProyecto = table.Column<int>(type: "int", nullable: false),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.CodTrabajo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    PerfilUsuario = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    CLave = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "CodProyecto", "Activo", "Direccion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Sanchez 33, Glew", 2, "Proyecto 001" },
                    { 2, true, "Santa fe 342, Lomas de Zamora", 1, "Proyecto 002" },
                    { 3, true, " Lavalle 1674, CABA", 2, "Proyecto 003" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "CodServicio", "Descr", "Estado", "ValorHora" },
                values: new object[,]
                {
                    { 1, "Servicio 001", true, 0.25m },
                    { 2, "Servicio 002", false, 0.25m },
                    { 3, "Servicio 003", true, 0.25m }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "CodTrabajo", "Activo", "CantHoras", "CodProyecto", "CodServicio", "Costo", "Fecha", "ValorHora" },
                values: new object[,]
                {
                    { 1, true, 28, 1, 2, 150m, new DateTime(2023, 9, 16, 22, 25, 25, 253, DateTimeKind.Local).AddTicks(4053), 0.25m },
                    { 2, true, 28, 2, 3, 180m, new DateTime(2023, 9, 16, 22, 25, 25, 253, DateTimeKind.Local).AddTicks(4071), 0.25m },
                    { 3, true, 28, 3, 3, 190m, new DateTime(2023, 9, 16, 22, 25, 25, 253, DateTimeKind.Local).AddTicks(4073), 0.25m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CodUsuario", "Activo", "CLave", "Dni", "Email", "Nombre", "PerfilUsuario" },
                values: new object[,]
                {
                    { 1, true, "665117e5124b9ff0cc0d4e8d408fdc2c8b9d026d070ccbdd84a0ce8da6285061", 31467581, "martin@gmail.com", "Martin Cabrera", 1 },
                    { 2, true, "9d3846caf71f436b90f7ea82a220d742aecc3134c5e41fa97f8ada2d87800c87", 37053098, "florencia@gmail.com", "Florencia Gonzalez", 2 },
                    { 3, true, "596f1c58d2fdc24d238dfbd538852855c03c74e1d2c394cb218fec9de06b5982", 58706438, "salome@gmail.com", "Salome Cabrera", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
