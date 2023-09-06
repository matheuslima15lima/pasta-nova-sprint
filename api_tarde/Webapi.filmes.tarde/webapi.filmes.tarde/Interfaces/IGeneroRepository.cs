using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoDeRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Cadastar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os gêneros cadastrados
        /// </summary>
        /// <returns>Uma Lista de Gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto atraves do seu id
        /// </summary>
        /// <param name="id">Objeto que sera buscado</param>
        /// <returns></returns>
        GeneroDomain BuscarPorId(int id);


        /// <summary>
        /// Atualizar um genero existente passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">objeto com as novas informacoes</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um gênero existente passando pelo o id pela URL da requisição
        /// </summary>
        /// <param name="Id">Id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int Id, GeneroDomain genero);

        /// <summary>
        /// Deletar um gênero existente
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        void Deletar(int id);
    }
}
