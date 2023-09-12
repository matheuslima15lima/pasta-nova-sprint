using Microsoft.EntityFrameworkCore.Query;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid Id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList(); 
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.ToList().Include(ICollection<Jogo>);

           
        }
    }
}
