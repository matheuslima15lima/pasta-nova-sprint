using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.inlock.CodeFirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "email obrigatorio")]
        //parei aqui
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha obrigatoria")]
        [StringLength(20,MinimumLength =6,ErrorMessage = "Senha de 6 a 20 caracteres!")]
        public string Senha { get; set; }

    }
}
