using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechOil.Entities
{
    public class Proyectos
    {
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
