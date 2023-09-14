using Webapi.inlock.CodeFirst.Domains;

namespace Webapi.inlock.CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario BuscarUsuario(string email, string senha);

        public void Cadastrar(Usuario usuario);
        
    }
}
