
using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// cadastrar um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Novo estudio a ser cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);
        List<EstudioDomain> ListarTodos();

        void Deletar(int id);
    }
}
