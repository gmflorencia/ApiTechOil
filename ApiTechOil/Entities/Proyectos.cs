using ApiTechOil.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ApiTechOil.Entities
{
    public class Proyectos
    {
        public Proyectos(ProyectosDto proyectosDto)
        {
            Nombre = proyectosDto.Nombre;
            Direccion = proyectosDto.Direccion;
            Estado = proyectosDto.Estado;
            Activo = true;    
        }
        public Proyectos(ProyectosDto dto, int codProyecto)
        {
            CodProyecto = codProyecto;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
            Activo = true;
        }
        public Proyectos()
        {

        }

        [Key]
        [Column ("CodProyecto", TypeName = "int")]
        public int CodProyecto { get; set; }
        [Required]
        [Column ("Nombre", TypeName = "VARCHAR (100)")]
        public string Nombre { get; set; }
        [Required]
        [Column ("Direccion", TypeName = "VARCHAR (100)")]
        public string Direccion { get; set; }
        [Required]
        [Column ("Estado", TypeName = "int")]
        public int Estado { get; set; }
        [Required]
        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; }


    }
}
