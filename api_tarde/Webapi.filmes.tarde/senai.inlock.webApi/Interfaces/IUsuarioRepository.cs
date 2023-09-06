using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {   
        /// <summary>
        /// Método que busca um usuario por email e senha 
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">sena do usuario</param>
        /// <returns></returns>
        UsuarioDomain Login(string email, string senha);
    }
}
