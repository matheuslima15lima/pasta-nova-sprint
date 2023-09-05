using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de estudio
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do estudio é obrigatório!")]
        public string? Nome { get; set; }
    }
}
