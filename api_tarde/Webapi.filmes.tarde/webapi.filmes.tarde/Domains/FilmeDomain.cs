using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage ="O título do filme é obrigatorio!")]
        public string? Titulo { get; set;}

        public int IdGenero { get; set;}

        //referência para a classe genero
        public GeneroDomain? Genero { get; set; }
    }
}
