﻿using ApiTechOil.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechOil.Entities
{
    public class Trabajo
    {
        public Trabajo(TrabajoDto trabajosDto)
        {
            Fecha= trabajosDto.Fecha;
            CodServicio= trabajosDto.CodServicio;
            CodProyecto= trabajosDto.CodProyecto;
            CantHoras= trabajosDto.CantHoras;
            ValorHora= trabajosDto.ValorHora;
            Costo= trabajosDto.Costo;
            Activo = true;
        }
        public Trabajo(TrabajoDto dto, int codTrabajo)
        {
            CodTrabajo= codTrabajo;
            CodProyecto= dto.CodProyecto;
            CodServicio= dto.CodServicio;
            Fecha= dto.Fecha;
            CantHoras= dto.CantHoras;
            ValorHora= dto.ValorHora;
            Costo = dto.Costo;
            Activo = true;
        }
        public Trabajo()
        {

        }

        [Key]
        [Column("CodTrabajo", TypeName = "int")]
        public int CodTrabajo { get; set; }
        
        [Required]
        [Column ("Fecha", TypeName = "Date")]        
        public DateTime Fecha { get; set; }
        
        [Required]
        [Column("CodProyecto")]
        public int CodProyecto { get; set; }

        [ForeignKey("CodProyecto")]
        public Proyecto Proyectos { get; set; }
        
        [Required]
        [Column("CodServicio")]
        public int CodServicio { get; set; }

        [ForeignKey("CodServicio")]
        public Servicio Servicios { get; set; }
        
        [Required]
        [Column ("CantHoras", TypeName = "int")]  
        public int CantHoras { get; set; }
        
        [Required]
        [Column ("ValorHora", TypeName = "decimal")]
        public double ValorHora { get; set; }
        
        [Required]
        [Column ("Costo", TypeName = "decimal")]
        public double Costo { get; set; }
        
        [Required]
        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; }


    }
}
