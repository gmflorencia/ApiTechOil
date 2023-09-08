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
                    Estado = table.Column<int>(type: "int", nullable: false)
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
                    Costo = table.Column<decimal>(type: "decimal(38,17)", nullable: false)
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
                    CLave = table.Column<string>(type: "VARCHAR (100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "CodProyecto", "Direccion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sanchez 33, Glew", 2, "Proyecto 001" },
                    { 2, "Santa fe 342, Lomas de Zamora", 1, "Proyecto 002" },
                    { 3, " Lavalle 1674, CABA", 2, "Proyecto 003" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "CodServicio", "Descr", "Estado", "ValorHora" },
                values: new object[,]
                {
                    { 1, "Proyecto 001", true, 0.25m },
                    { 2, "Proyecto 002", false, 0.25m },
                    { 3, "Proyecto 003", true, 0.25m }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "CodTrabajo", "CantHoras", "CodProyecto", "CodServicio", "Costo", "Fecha", "ValorHora" },
                values: new object[,]
                {
                    { 1, 28, 1, 2, 150m, new DateTime(2023, 9, 8, 4, 3, 27, 734, DateTimeKind.Local).AddTicks(3419), 0.25m },
                    { 2, 28, 2, 3, 180m, new DateTime(2023, 9, 8, 4, 3, 27, 734, DateTimeKind.Local).AddTicks(3431), 0.25m },
                    { 3, 28, 3, 3, 190m, new DateTime(2023, 9, 8, 4, 3, 27, 734, DateTimeKind.Local).AddTicks(3432), 0.25m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CodUsuario", "CLave", "Dni", "Nombre", "PerfilUsuario" },
                values: new object[,]
                {
                    { 1, "1234", 31467581, "Martin Cabrera", 1 },
                    { 2, "5678", 37053098, "Florencia Gonzalez", 2 },
                    { 3, "5792", 58706438, "Salome Cabrera", 1 }
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
