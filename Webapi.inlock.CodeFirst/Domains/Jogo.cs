using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.inlock.CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatorio!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "descricao obrigatorio!")]
        public string ? Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento obrigatorio")]
        public string? DataLancamento { get; set; }


        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "Preco do jogo obrigatorio")]
        public decimal Preco { get; set; }

        //ref. tabela estudio

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }


    }
}
