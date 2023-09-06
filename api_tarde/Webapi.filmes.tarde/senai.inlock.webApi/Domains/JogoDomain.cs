using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage ="O Nome do jogo é obrigatório!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int IdEstudio { get; set; }

        public float Valor { get; set; }
        
        //referência para classe estudio
        public EstudioDomain? Estudio { get; set; }

    }
}
