using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechOil.Entities
{
    public class Usuario
    {
        [Key]
        [Column("CodUsuario", TypeName = "int")]
        public int CodUsuario { get; set; }
        [Required]
        [Column("Nombre", TypeName = "VARCHAR (100)")]
        public string Nombre { get; set; }  
        [Required]
        [Column("Dni", TypeName = "int")]
        public int Dni { get; set; }
        [Required]
        [Column("PerfilUsuario", TypeName = "int")]
        public int PerfilUsuario { get; set; }
        [Required]
        [Column("CLave", TypeName = "VARCHAR (100)")]
        public string Clave { get; set; }

    }
}
