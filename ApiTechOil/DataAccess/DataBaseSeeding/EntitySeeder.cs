using TechOilAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TechOilAPI.DataAccess.DataBaseSeeding
{
    public class EntitySeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                    new Usuario 
                    { 
                        CodUsuario = 1, Nombre = "Martin Cabrera", 
                        Dni = 31467581, 
                        PerfilUsuario = 1, 
                        Clave = "1234" 
                    },
                    new Usuario
                    {
                        CodUsuario = 2, 
                        Nombre = "Florencia Gonzalez", 
                        Dni = 37053098, 
                        PerfilUsuario = 2,
                        Clave = "5678" 
                    },
                    new Usuario
                    {
                        CodUsuario = 3, 
                        Nombre = "Salome Cabrera", 
                        Dni = 58706438, 
                        PerfilUsuario = 1, 
                        Clave = "5792" 
                    });
            modelBuilder.Entity<Proyectos>().HasData(
                    new Proyectos
                    {
                        CodProyecto = 1,
                        Nombre = "Proyecto 001",
                        Direccion = "Sanchez 33, Glew",
                        Estado = 2
                    },
                    new Proyectos
                    {
                        CodProyecto = 2,
                        Nombre = "Proyecto 002",
                        Direccion ="Santa fe 342, Lomas de Zamora",
                        Estado = 1
                    },
                    new Proyectos
                    {
                        CodProyecto = 3,
                        Nombre = "Proyecto 003",
                        Direccion = " Lavalle 1674, CABA",
                        Estado = 2,
                    });
            modelBuilder.Entity<Servicios>().HasData(
                    new Servicios
                    {
                        CodServicio = 1,
                        Descr = "Proyecto 001",
                        Estado = true,
                        ValorHora = 0.25,
                    },
                    new Servicios
                    {
                        CodServicio= 2,
                        Descr = "Proyecto 002",
                        Estado = false,
                        ValorHora = 0.25
                    },
                    new Servicios
                    {
                        CodServicio = 3,
                        Descr = "Proyecto 003",
                        Estado = true,
                        ValorHora = 0.25,
                    });
            modelBuilder.Entity<Trabajos>().HasData(
                    new Trabajos
                    {
                        CodTrabajo = 1,
                        Fecha = DateTime.Now,
                        CodProyecto = 1,
                        CodServicio = 2,
                        CantHoras = 28,
                        ValorHora= 0.25,
                        Costo = 150.000,
                    },
                    new Trabajos
                    {
                        CodTrabajo = 2,
                        Fecha = DateTime.Now,
                        CodProyecto = 2,
                        CodServicio = 3,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 180.000,

                    },
                    new Trabajos
                    {
                        CodTrabajo = 3,
                        Fecha = DateTime.Now,
                        CodProyecto = 3,
                        CodServicio = 3,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 190.000,

                    });
        }
    }
}
