using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiTechOil.DTOs;

namespace ApiTechOil.Entities
{
    public class PerfilUsuario
    {
        public PerfilUsuario(PerfilUsuarioDto dto)
        {
            Descripcion = dto.Descripcion;
            Activo = true;
        }
        public PerfilUsuario(PerfilUsuarioDto dto, int id)
        {
            Id = id;
            Descripcion = dto.Descripcion;
            Activo = true;
        }
        public PerfilUsuario()
        {

        }

        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column("Descripcion", TypeName = "VARCHAR (100)")]
        public string Descripcion { get; set; }      
        
        [Required]
        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; }
    }
}
