using ApiTechOil.DTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTechOil.Helpers;

namespace ApiTechOil.Entities
{
    public class Usuario
    {
        public Usuario(UsuarioDto registerDto)
        {
            Nombre = registerDto.Nombre;
            Dni = registerDto.Dni;
            Email = registerDto.Email;
            Clave = ClaveEncryptHelper.EncryptClave(registerDto.Clave, registerDto.Email);
            Activo = true;
            CodRol = registerDto.CodRol;
        }
        public Usuario(UsuarioDto registerDto, int codUsuario)
        {
            CodUsuario = codUsuario;
            Nombre = registerDto.Nombre;
            Dni = registerDto.Dni;
            Email = registerDto.Email;
            Clave = ClaveEncryptHelper.EncryptClave(registerDto.Clave, registerDto.Email);
            Activo = true;
            CodRol = registerDto.CodRol;
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
        [Column("CodRol")]
        public int CodRol { get; set; }

        [ForeignKey("CodRol")]
        public Rol Roles { get; set; }

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
