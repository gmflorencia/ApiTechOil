namespace ApiTechOil.DTOs
{
    public class TrabajoDto
    {
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public DateTime Fecha { get; set; }
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }
    }
}
