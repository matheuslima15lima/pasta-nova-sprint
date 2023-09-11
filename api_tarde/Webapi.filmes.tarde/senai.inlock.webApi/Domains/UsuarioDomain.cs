using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório!!!")]
        public String Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa de no minimo 3 e no máximo 20")]
        public String Senha { get; set; }

        public int IdTipoUsuario { get; set; }
    }
}
