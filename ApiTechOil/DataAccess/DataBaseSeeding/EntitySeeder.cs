﻿using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;
using ApiTechOil.Helpers;
using System.Collections.Generic;
using System.Data;
using ApiTechOil.DTOs;

namespace ApiTechOil.DataAccess.DataBaseSeeding
{
    public class EntitySeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                    new Usuario
                    {
                        CodUsuario = 1,
                        Nombre = "Martin Cabrera",
                        Dni = 31467581,
                        CodRol = 1,
                        Email = "martin@gmail.com",
                        Clave = ClaveEncryptHelper.EncryptClave("1234", "martin@gmail.com"),
                        Activo = true

                    },
                    new Usuario
                    {
                        CodUsuario = 2,
                        Nombre = "Florencia Gonzalez",
                        Dni = 37053098,
                        CodRol = 2,
                        Email = "florencia@gmail.com",
                        Clave = ClaveEncryptHelper.EncryptClave("5678", "florencia@gmail.com"),
                        Activo = true
                    },
                    new Usuario
                    {
                        CodUsuario = 3,
                        Nombre = "Salome Cabrera",
                        Dni = 58706438,
                        CodRol = 1,
                        Email = "salome@gmail.com",
                        Clave = ClaveEncryptHelper.EncryptClave("5792", "salome@gmail.com"),
                        Activo = true

                    });
            modelBuilder.Entity<Proyecto>().HasData(
                    new Proyecto
                    {
                        CodProyecto = 1,
                        Nombre = "Proyecto 001",
                        Direccion = "Sanchez 33, Glew",
                        Estado = 2,
                        Activo = true

                    },
                    new Proyecto
                    {
                        CodProyecto = 2,
                        Nombre = "Proyecto 002",
                        Direccion = "Santa fe 342, Lomas de Zamora",
                        Estado = 1,
                        Activo = true
                    },
                    new Proyecto
                    {
                        CodProyecto = 3,
                        Nombre = "Proyecto 003",
                        Direccion = " Lavalle 1674, CABA",
                        Estado = 2,
                        Activo = true
                    });
            modelBuilder.Entity<Servicio>().HasData(
                    new Servicio
                    {
                        CodServicio = 1,
                        Descr = "Servicio 001",
                        Estado = true,
                        ValorHora = 0.25,
                    },
                    new Servicio
                    {
                        CodServicio = 2,
                        Descr = "Servicio 002",
                        Estado = false,
                        ValorHora = 0.25,
                    },
                    new Servicio
                    {
                        CodServicio = 3,
                        Descr = "Servicio 003",
                        Estado = true,
                        ValorHora = 0.25,
                    });
            modelBuilder.Entity<Trabajo>().HasData(
                    new Trabajo
                    {
                        CodTrabajo = 1,
                        Fecha = DateTime.Now,
                        CodProyecto = 1,
                        CodServicio = 2,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 150.000,
                        Activo = true
                    },
                    new Trabajo
                    {
                        CodTrabajo = 2,
                        Fecha = DateTime.Now,
                        CodProyecto = 2,
                        CodServicio = 3,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 180.000,
                        Activo = true

                    },
                    new Trabajo
                    {
                        CodTrabajo = 3,
                        Fecha = DateTime.Now,
                        CodProyecto = 3,
                        CodServicio = 3,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 190.000,
                        Activo = true

                    });
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    CodRol = 1,
                    Descripcion = "Administrador",
                    Activo = true,
                },
                new Rol
                {
                    CodRol = 2,
                    Descripcion = "Consultor",
                    Activo = true,
                });
        }
    }
}
