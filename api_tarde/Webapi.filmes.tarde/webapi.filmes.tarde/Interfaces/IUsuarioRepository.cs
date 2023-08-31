using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Metodo que busca um usuario por email e senha
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>Objeto que foi buscado</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
