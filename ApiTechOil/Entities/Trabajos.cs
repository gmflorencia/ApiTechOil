using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechOil.Entities
{
    public class Trabajos
    {
        [Key]
        [Column("CodTrabajo", TypeName = "int")]
        public int CodTrabajo { get; set; }
        [Required]
        [Column ("Fecha", TypeName = "Date")]
        public DateTime Fecha { get; set; }
        [Required]
        [ForeignKey ("Proyectos")]
        public int CodProyecto { get; set; }
        [Required]
        [ForeignKey ("Servicios")]
        public int CodServicio { get; set; }
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
