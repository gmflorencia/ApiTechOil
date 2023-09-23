using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiTechOil.DTOs;

namespace ApiTechOil.Entities
{
    public class Rol
    {
        public Rol(RolDto dto)
        {
            Descripcion = dto.Descripcion;
            Activo = true;
        }
        public Rol(RolDto dto, int id)
        {
            CodRol = id;
            Descripcion = dto.Descripcion;
            Activo = true;
        }
        public Rol()
        {

        }

        [Key]
        [Column("CodRol", TypeName = "int")]
        public int CodRol { get; set; }

        [Required]
        [Column("Descripcion", TypeName = "VARCHAR (100)")]
        public string Descripcion { get; set; }      
        
        [Required]
        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; }
    }
}
