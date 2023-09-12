using System.Text.Json.Serialization;

namespace ApiTechOil.DTOs
{
    public class RegisterDto
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
