using ApiTechOil.DTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTechOil.Helpers;

namespace ApiTechOil.Entities
{
    public class Usuario
    {
        public Usuario(RegisterDto registerDto)
        {
            Nombre = registerDto.Nombre;
            Dni = registerDto.Dni;
            Email = registerDto.Email;
            Clave = ClaveEncryptHelper.EncryptClave(registerDto.Clave, registerDto.Email);
            Activo = true;
            PerfilUsuario = 1;
        }
        public Usuario(RegisterDto registerDto, int codUsuario)
        {
            CodUsuario = codUsuario;
            Nombre = registerDto.Nombre;
            Dni = registerDto.Dni;
            Email = registerDto.Email;
            Clave = ClaveEncryptHelper.EncryptClave(registerDto.Clave, registerDto.Email);
            Activo = true;
            PerfilUsuario = 1;
        }
        public Usuario()
        {

        }

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
        [Column("PerfilUsuario")]
        public int PerfilUsuario { get; set; }

        [ForeignKey("PerfilUsuario")]
        public PerfilUsuario Id { get; set; }

        [Required]
        [Column("Email", TypeName = "VARCHAR (100)")]
        public string Email { get; set; }

        [Required]
        [Column("CLave", TypeName = "VARCHAR (100)")]
        public string Clave { get; set; }

        [Required]
        [Column ("Activo", TypeName = "bit")]
        public bool Activo { get; set; }


    }
}
