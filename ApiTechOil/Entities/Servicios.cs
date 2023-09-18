using ApiTechOil.DTOs;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechOil.Entities
{
    public class Servicios
    {
        public Servicios(ServiciosDto serviciosDto )
        {
            Descr = serviciosDto.Descr;
            Estado = true;
            ValorHora = serviciosDto.ValorHora;
            
        }
        public Servicios(ServiciosDto dto, int codServicio)
        {
            CodServicio = codServicio;
            Descr= dto.Descr;
            Estado= true;
            ValorHora = dto.ValorHora;
        }
        public Servicios()
        {

        }

        [Key]
        [Column ( "CodServicio", TypeName = "int")]
        public int CodServicio { get; set; }

        [Required]
        [Column("Descr", TypeName = "VARCHAR (100)")]
        public string Descr { get; set; }

        [Required]
        [Column("Estado", TypeName = "bit")]
        public bool Estado { get; set; }

        [Required]
        [Column ("ValorHora", TypeName = "decimal")]
        public double ValorHora { get; set; }

    }
}
