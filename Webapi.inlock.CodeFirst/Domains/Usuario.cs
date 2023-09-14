using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.inlock.CodeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "email obrigatorio")]
        //parei aqui
       
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Senha obrigatoria")]
        [StringLength(60,MinimumLength =6,ErrorMessage = "Senha de 6 a 60 caracteres!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Tipo usuario obrigatorio")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey ("IdTipoUsuario")]
        public TiposUsuario? TiposUsuario { get; set; }

    }
}
