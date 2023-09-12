using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(Guid Id);

        void Cadastrar(Estudio estudio);

        void Atualizar(Guid Id, Estudio estudio);

        void Deletar(Guid Id);

        List<Estudio> ListarComJogos();

    }
}
