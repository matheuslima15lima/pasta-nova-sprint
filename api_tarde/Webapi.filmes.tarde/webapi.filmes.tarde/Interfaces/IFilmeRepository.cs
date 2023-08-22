using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

       FilmeDomain BuscarPorId(int Id);

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarIdUrl(int Id, FilmeDomain filme);

        void Deletar(int id);
    }
}
